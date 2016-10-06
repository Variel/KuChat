(function() {
    angular
        .module('kuchat')
        .constant('$', window.jQuery)
        .factory('Hub', hubFactory);

    hubFactory.$inject = ['$', '$rootScope'];

    function hubFactory($, $rootScope) {
        return function (name, callbacks, methods) {
            var hub = this;

            hub.connection = $.hubConnection();
            hub.proxy = hub.connection.createHubProxy(name);

            hub.disconnect = function () {
                hub.connection.stop();
            };

            hub.connect = function () {
                return hub.connection.start({});
            };

            if(callbacks) {
                Object.getOwnPropertyNames(callbacks)
                    .filter(function(prop) {
                        return typeof(callbacks[prop]) === 'function';
                    })
                    .forEach(function(prop) {
                        hub.proxy.on(prop,
                            function() {
                                callbacks[prop].apply(hub, arguments);
                                $rootScope.$apply();
                            });
                    });
            }

            if (methods) {
                methods.forEach(function(method) {
                    hub[method] = function() {
                        var args = $.makeArray(arguments);
                        args.unshift(method);
                        return hub.proxy.invoke.apply(hub.proxy, args);
                    };
                });
            }

            hub.connection.stateChanged(function(state) {
                switch (state.newState) {
                    case $.signalR.connectionState.connecting:
                        if (hub.onConnecting) {
                            hub.onConnecting();
                        }
                        break;
                    case $.signalR.connectionState.connected:
                        if (hub.onConnected) {
                            hub.onConnected();
                        }
                        break;
                    case $.signalR.connectionState.reconnecting:
                        if (hub.onReconnecting) {
                            hub.onReconnecting();
                        }
                        break;
                    case $.signalR.connectionState.disconnected:
                        if (hub.onDisconnected) {
                            hub.onDisconnected();
                        }
                        break;
                }

                $rootScope.$apply();
            });

            hub.connect();
        }
    }
})();