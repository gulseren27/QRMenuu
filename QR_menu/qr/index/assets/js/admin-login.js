
!function (l) { "use strict"; l("#sidebarToggle, #sidebarToggleTop").on("click", function (e) { l("body").toggleClass("sidebar-toggled"), l(".sidebar").toggleClass("toggled"), l(".sidebar").hasClass("toggled") && l(".sidebar .collapse").collapse("hide") }), l(window).resize(function () { l(window).width() < 768 && l(".sidebar .collapse").collapse("hide"), l(window).width() < 480 && !l(".sidebar").hasClass("toggled") && (l("body").addClass("sidebar-toggled"), l(".sidebar").addClass("toggled"), l(".sidebar .collapse").collapse("hide")) }), l("body.fixed-nav .sidebar").on("mousewheel DOMMouseScroll wheel", function (e) { var o; 768 < l(window).width() && (o = (o = e.originalEvent).wheelDelta || -o.detail, this.scrollTop += 30 * (o < 0 ? 1 : -1), e.preventDefault()) }), l(document).on("scroll", function () { 100 < l(this).scrollTop() ? l(".scroll-to-top").fadeIn() : l(".scroll-to-top").fadeOut() }), l(document).on("click", "a.scroll-to-top", function (e) { var o = l(this); l("html, body").stop().animate({ scrollTop: l(o.attr("href")).offset().top }, 1e3, "easeInOutExpo"), e.preventDefault() }) }(jQuery);






////document.getElementById('loginForm').addEventListener('submit', async function(e) {
////    e.preventDefault();

////    const username = document.getElementById('username').value;
////    const password = document.getElementById('password').value;

////    try {
////        const response = await fetch('../admin/login.php', {
////            method: 'POST',
////            headers: {
////                'Content-Type': 'application/json'
////            },
////            body: JSON.stringify({
////                username: username,
////                password: password
////            })
////        });

////        const data = await response.json();

////        if (data.success) {
////            // Başarılı giriş, dashboard'a yönlendir
////            window.location.href = 'dashboard.html';
////        } else {
////            alert('Kullanıcı adı veya şifre hatalı!');
////        }
////    } catch (error) {
////        console.error('Giriş hatası:', error);
////        alert('Giriş yapılırken bir hata oluştu!');
////    }
////}); 