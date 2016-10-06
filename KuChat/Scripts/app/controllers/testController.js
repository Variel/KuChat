(function() {
    angular
        .module('kuchat')
        .controller('testController', testController);

    testController.$inject = ['Hub'];

    function testController(Hub) {
        var vm = this;

        var handlers = {
            'newMessage': onNewMessage,
            'joinChannel': onJoinChannel,
            'leaveChannel': onLeaveChannel
        }
        var methods = ['sendMessage'];
        var hub = new Hub('chatHub', handlers, methods);

        hub.onConnected = function () {
            var fn = function () {
                hub.sendMessage('a2d2a066-6549-459e-805b-b303fc5b30a2', 'echo');
                setTimeout(fn, 2000);
            }
            fn();
        }

        function onNewMessage(ch, user, msg) {
            console.log(`new message from ${user.name}: ${msg}`);
        }

        function onJoinChannel(ch, user) {
        }

        function onLeaveChannel(ch, user) {
        }
    }
})();