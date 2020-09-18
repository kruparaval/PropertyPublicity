(function ($) {
    var _aminityService = abp.services.app.aminity,
        l = abp.localization.getSource('PropertyPublicity'),
        _$modal = $('#AminityCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#AminitiesTable');


    var _$aminitiesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#AminitySearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _aminityService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$AminitiesTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            
            {
                targets: 2,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-aminity" data-aminity-id="${row.id}" data-toggle="modal" data-target="#AminityEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-aminity" data-aminity-id="${row.id}" data-aminity-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var aminity = _$form.serializeFormToObject();
        abp.ui.setBusy(_$modal);
        _aminityService
            .create(aminity)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$aminitiesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-aminity', function () {
        var aminityId = $(this).attr("data-aminity-id");
        var AminityName = $(this).attr('data-aminity-name');

        deleteaminity(aminityId, AminityName);
    });

    $(document).on('click', '.edit-aminity', function (e) {
        var aminityId = $(this).attr("data-aminity-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Aminities/EditModal?aminityId=' + aminityId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#AminityEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('aminity.edited', (data) => {
        _$aminitiesTable.ajax.reload();
    });

    function deleteaminity(aminityId, aminityName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                aminityName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _aminityService.delete({
                        id: aminityId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$aminitiesTable.ajax.reload();
                    });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$AminitiesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$AminitiesTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
