var Hello;
(function (Hello) {
    (function (Foo) {
        var FooBar = (function () {
            function FooBar() { }
            return FooBar;
        })();        
        var Hoo;
        (function (Hoo) {
            (function (Bar) {
                var HooBar = (function () {
                    function HooBar() { }
                    return HooBar;
                })();                
            })(Hoo.Bar || (Hoo.Bar = {}));
            var Bar = Hoo.Bar;

        })(Hoo || (Hoo = {}));

    })(Hello.Foo || (Hello.Foo = {}));
    var Foo = Hello.Foo;

})(Hello || (Hello = {}));

