(function ($) {
    var _areaService = abp.services.app.area,
        l = abp.localization.getSource('PropertyPublicity'),
        _$modal = $('#AreaCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#AreasTable');


    var _$areasTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#AreaSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _areaService.getAll(filter).done(function (result) {
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
                action: () => _$areasTable.draw(false)
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
                data: 'isActive',
                sortable: false,
                render: data => `<span class="fa fa-${data ? 'check' : 'times'}" style="color:${data ? 'green' : 'red'}"></span>`
            }, 
            {
                targets: 3,
                data: 'cityName',
                sortable: false
            },

            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-area" data-area-id="${row.id}" data-toggle="modal" data-target="#AreaEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-area" data-area-id="${row.id}" data-area-name="${row.name}">`,
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

        var area = _$form.serializeFormToObject();
        abp.ui.setBusy(_$modal);
        _areaService
            .create(area)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$areasTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-city', function () {
        var areaId = $(this).attr("data-area-id");
        var AreaName = $(this).attr('data-area-name');

        deleteCity(areaId, areaName);
    });

    $(document).on('click', '.edit-area', function (e) {
        var areaId = $(this).attr("data-area-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Areas/EditModal?areaId=' + areaId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#AreaEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('area.edited', (data) => {
        _$areasTable.ajax.reload();
    });

    function deleteState(areaId, areaName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                areaName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _areaService.delete({
                        id: areaId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$AreasTable.ajax.reload();
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
        _$areasTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$areasTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
