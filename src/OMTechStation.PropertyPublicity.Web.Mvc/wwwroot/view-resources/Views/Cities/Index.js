(function ($) {
    var _cityService = abp.services.app.city,
        l = abp.localization.getSource('PropertyPublicity'),
        _$modal = $('#CityCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#CitiesTable');


    var _$citiesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#CitySearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _cityService.getAll(filter).done(function (result) {
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
                action: () => _$citiesTable.draw(false)
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
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-city" data-city-id="${row.id}" data-toggle="modal" data-target="#CityEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-city" data-city-id="${row.id}" data-city-name="${row.name}">`,
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

        var city = _$form.serializeFormToObject();
        city.grantedPermissions = [];
        var _$permissionCheckboxes = _$form[0].querySelectorAll("input[name='permission']:checked");
        if (_$permissionCheckboxes) {
            for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                city.grantedPermissions.push(_$permissionCheckbox.val());
            }
        }

       
        abp.ui.setBusy(_$modal);
        _countryService
            .create(country)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$countriesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-country', function () {
        var countryId = $(this).attr("data-country-id");
        var countryName = $(this).attr('data-country-name');

        deleteCountry(countryId, countryName);
    });

    $(document).on('click', '.edit-country', function (e) {
        var countryId = $(this).attr("data-country-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Countries/EditModal?countryId=' + countryId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#CountryEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('country.edited', (data) => {
        _$countriesTable.ajax.reload();
    });

    function deleteCountry(countryId, countryName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                countryName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _countryService.delete({
                        id: countryId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$countriesTable.ajax.reload();
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
        _$countriesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$countriesTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
