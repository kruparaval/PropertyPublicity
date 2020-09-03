(function ($) {
    var _stateService = abp.services.app.state,
        l = abp.localization.getSource('PropertyPublicity'),
        _$modal = $('#StateCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#StatesTable');


    var _$statesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#StateSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _stateService.getAll(filter).done(function (result) {
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
                action: () => _$statesTable.draw(false)
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
                data: 'countryName',
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
                        `   <button type="button" class="btn btn-sm bg-secondary edit-state" data-state-id="${row.id}" data-toggle="modal" data-target="#StateEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-state" data-state-id="${row.id}" data-state-name="${row.name}">`,
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

        var state = _$form.serializeFormToObject();
        state.grantedPermissions = [];
        var _$permissionCheckboxes = _$form[0].querySelectorAll("input[name='permission']:checked");
        if (_$permissionCheckboxes) {
            for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                state.grantedPermissions.push(_$permissionCheckbox.val());
            }
        }

       
        abp.ui.setBusy(_$modal);
        _stateService
            .create(state)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$statesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-state', function () {
        var stateId = $(this).attr("data-state-id");
        var stateName = $(this).attr('data-state-name');

        deleteState(stateId, stateName);
    });

    $(document).on('click', '.edit-state', function (e) {
        var stateId = $(this).attr("data-state-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'States/EditModal?stateId=' + stateId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#StateEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('state.edited', (data) => {
        _$statesTable.ajax.reload();
    });

    function deleteState(stateId, stateName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                stateName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _stateService.delete({
                        id: stateId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$statesTable.ajax.reload();
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
        _$statesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$statesTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
