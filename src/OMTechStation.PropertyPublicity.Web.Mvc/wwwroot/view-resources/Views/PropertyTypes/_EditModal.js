﻿(function ($) {
    var _propertytypeService = abp.services.app.propertyType,
        l = abp.localization.getSource('PropertyPublicity'),
        _$modal = $('#PropertyTypeEditModal'),
        _$form = _$modal.find('form');

    function save() {
        
        if (!_$form.valid()) {
            return;
        }
        var propertytype = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);
        _propertytypeService.update(propertytype).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('propertytype.edited', propertytype );
            
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
