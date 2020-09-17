(function ($) {
    var _propertytypeService = abp.services.app.propertyType,
        l = abp.localization.getSource('PropertyPublicity'),
        _$modal = $('#PropertyTypeCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#PropertyTypesTable');


    var _$propertytypesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#PropertytypeSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _propertytypeService.getAll(filter).done(function (result) {
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
                action: () => _$PropertyTypesTable.draw(false)
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
                        `   <button type="button" class="btn btn-sm bg-secondary edit-propertytype" data-propertytype-id="${row.id}" data-toggle="modal" data-target="#PropertyTypeEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-propertytype" data-propertytype-id="${row.id}" data-propertytype-name="${row.name}">`,
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

        var propertytype = _$form.serializeFormToObject();
        abp.ui.setBusy(_$modal);
        _propertytypeService
            .create(propertytype)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$propertytypesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-propertytype', function () {
        var propertytypeId = $(this).attr("data-propertytype-id");
        var PropertytypeName = $(this).attr('data-propertytype-name');

        deletepropertytype(propertytypeId, PropertytypeName);
    });

    $(document).on('click', '.edit-propertytype', function (e) {
        var propertytypeId = $(this).attr("data-propertytype-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Propertytypes/EditModal?propertytypeId=' + propertytypeId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#PropertyTypeEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('propertytype.edited', (data) => {
        _$propertytypesTable.ajax.reload();
    });

    function deletepropertytype(propertytypeId, propertytypeName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                propertytypeName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _propertytypeService.delete({
                        id: propertytypeId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$PropertytypesTable.ajax.reload();
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
        _$propertytypesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$propertytypesTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
