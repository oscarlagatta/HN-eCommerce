(function (cr) {
    var CurrentCultureModel = function () {

        var self = this;

        self.initialized = false;
        self.Culture = '';
    }
    cr.CurrentCultureModel = CurrentCultureModel;
}(window.eCommerce));