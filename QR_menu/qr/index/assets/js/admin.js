


//!function (l) { "use strict"; l("#sidebarToggle, #sidebarToggleTop").on("click", function (e) { l("body").toggleClass("sidebar-toggled"), l(".sidebar").toggleClass("toggled"), l(".sidebar").hasClass("toggled") && l(".sidebar .collapse").collapse("hide") }), l(window).resize(function () { l(window).width() < 768 && l(".sidebar .collapse").collapse("hide"), l(window).width() < 480 && !l(".sidebar").hasClass("toggled") && (l("body").addClass("sidebar-toggled"), l(".sidebar").addClass("toggled"), l(".sidebar .collapse").collapse("hide")) }), l("body.fixed-nav .sidebar").on("mousewheel DOMMouseScroll wheel", function (e) { var o; 768 < l(window).width() && (o = (o = e.originalEvent).wheelDelta || -o.detail, this.scrollTop += 30 * (o < 0 ? 1 : -1), e.preventDefault()) }), l(document).on("scroll", function () { 100 < l(this).scrollTop() ? l(".scroll-to-top").fadeIn() : l(".scroll-to-top").fadeOut() }), l(document).on("click", "a.scroll-to-top", function (e) { var o = l(this); l("html, body").stop().animate({ scrollTop: l(o.attr("href")).offset().top }, 1e3, "easeInOutExpo"), e.preventDefault() }) }(jQuery);














////// DOM yüklendiğinde çalışacak kodlar
////document.addEventListener('DOMContentLoaded', function() {
////    // Sayfa yüklendiğinde kategorileri ve ürünleri getir
////    loadCategories();
////    loadProducts();

////    // Event Listener'ları ekle
////    document.getElementById('addCategoryBtn').addEventListener('click', showAddCategoryModal);
////    document.getElementById('addProductBtn').addEventListener('click', showAddProductModal);
////    document.querySelector('.close').addEventListener('click', closeModal);
////});

////// Kategorileri yükle
////async function loadCategories() {
////    try {
////        const response = await fetch('../includes/get_categories.php');
////        const categories = await response.json();
        
////        const categoriesList = document.getElementById('categories-list');
////        categoriesList.innerHTML = '';

////        categories.forEach(category => {
////            const categoryElement = createCategoryElement(category);
////            categoriesList.appendChild(categoryElement);
////        });
////    } catch (error) {
////        console.error('Kategoriler yüklenirken hata:', error);
////    }
////}

////// Ürünleri yükle
////async function loadProducts() {
////    try {
////        const response = await fetch('../includes/get_products.php');
////        const products = await response.json();
        
////        const productsList = document.getElementById('products-list');
////        productsList.innerHTML = '';

////        products.forEach(product => {
////            const productElement = createProductElement(product);
////            productsList.appendChild(productElement);
////        });
////    } catch (error) {
////        console.error('Ürünler yüklenirken hata:', error);
////    }
////}

////// Kategori elementi oluştur
////function createCategoryElement(category) {
////    const div = document.createElement('div');
////    div.className = 'category-item';
////    div.innerHTML = `
////        <div class="category-info">
////            <h3>${category.name}</h3>
////        </div>
////        <div class="category-actions">
////            <button onclick="editCategory(${category.id})">
////                <i class="fas fa-edit"></i>
////            </button>
////            <button onclick="deleteCategory(${category.id})">
////                <i class="fas fa-trash"></i>
////            </button>
////        </div>
////    `;
////    return div;
////}

////// Ürün elementi oluştur
////function createProductElement(product) {
////    const div = document.createElement('div');
////    div.className = 'product-item';
////    div.innerHTML = `
////        <div class="product-info">
////            <img src="${product.image}" alt="${product.name}">
////            <div class="product-details">
////                <h3>${product.name}</h3>
////                <p>${product.description}</p>
////                <span class="price">${product.price} TL</span>
////            </div>
////        </div>
////        <div class="product-actions">
////            <button onclick="editProduct(${product.id})">
////                <i class="fas fa-edit"></i>
////            </button>
////            <button onclick="deleteProduct(${product.id})">
////                <i class="fas fa-trash"></i>
////            </button>
////        </div>
////    `;
////    return div;
////}

////// Modal işlemleri
////function showModal(content) {
////    const modal = document.getElementById('modal');
////    const modalBody = document.getElementById('modal-body');
////    modalBody.innerHTML = content;
////    modal.style.display = 'block';
////}

////function closeModal() {
////    const modal = document.getElementById('modal');
////    modal.style.display = 'none';
////}

////// Kategori işlemleri
////function showAddCategoryModal() {
////    const content = `
////        <h2>Yeni Kategori Ekle</h2>
////        <form id="addCategoryForm">
////            <div class="form-group">
////                <label for="categoryName">Kategori Adı:</label>
////                <input type="text" id="categoryName" required>
////            </div>
////            <button type="submit">Ekle</button>
////        </form>
////    `;
////    showModal(content);
////}

////// Ürün işlemleri
////function showAddProductModal() {
////    const content = `
////        <h2>Yeni Ürün Ekle</h2>
////        <form id="addProductForm">
////            <div class="form-group">
////                <label for="productName">Ürün Adı:</label>
////                <input type="text" id="productName" required>
////            </div>
////            <div class="form-group">
////                <label for="productDescription">Açıklama:</label>
////                <textarea id="productDescription" required></textarea>
////            </div>
////            <div class="form-group">
////                <label for="productPrice">Fiyat:</label>
////                <input type="number" id="productPrice" step="0.01" required>
////            </div>
////            <div class="form-group">
////                <label for="productImage">Resim:</label>
////                <input type="file" id="productImage" accept="image/*" required>
////            </div>
////            <div class="form-group">
////                <label for="productCategory">Kategori:</label>
////                <select id="productCategory" required>
////                    <!-- Kategoriler JavaScript ile doldurulacak -->
////                </select>
////            </div>
////            <button type="submit">Ekle</button>
////        </form>
////    `;
////    showModal(content);
////}

////// Sidebar Toggle Fonksiyonu
////function toggleSidebar() {
////    const sidebar = document.querySelector('.sidebar');
////    sidebar.classList.toggle('active');
////}

////// Sayfa yüklendiğinde ekran genişliğini kontrol et
////window.addEventListener('load', function() {
////    if (window.innerWidth > 768) {
////        document.querySelector('.sidebar').classList.add('active');
////    }
////});

////// Ekran boyutu değiştiğinde kontrol et
////window.addEventListener('resize', function() {
////    if (window.innerWidth > 768) {
////        document.querySelector('.sidebar').classList.add('active');
////    } else {
////        document.querySelector('.sidebar').classList.remove('active');
////    }
////});

////// Ana içerik alanına tıklandığında mobilde sidebar'ı kapat
////document.querySelector('.main-content').addEventListener('click', function() {
////    if (window.innerWidth <= 768) {
////        document.querySelector('.sidebar').classList.remove('active');
////    }
////}); 


