(function ($) {
    var _stateService = abp.services.app.state,
        l = abp.localization.getSource('PropertyPublicity'),
        _$modal = $('#StateEditModal'),
        _$form = _$modal.find('form');

    function save() {
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

        abp.ui.setBusy(_$form);
        _stateService.update(state).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('state.edited', state);
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
