// Sayfa yüklendiğinde çalışacak ana fonksiyon
document.addEventListener('DOMContentLoaded', function() {
    loadCategories();
});

// Kategorileri yükleyen fonksiyon
async function loadCategories() {
    try {
        const response = await fetch('includes/get_categories.php');
        const categories = await response.json();
        
        const container = document.getElementById('categories-container');
        
        categories.forEach(category => {
            const categoryElement = createCategoryElement(category);
            container.appendChild(categoryElement);
        });
    } catch (error) {
        console.error('Kategoriler yüklenirken hata oluştu:', error);
    }
}

// Kategori elementi oluşturan fonksiyon
function createCategoryElement(category) {
    const categoryDiv = document.createElement('div');
    categoryDiv.className = 'category';
    categoryDiv.innerHTML = `
        <h2>${category.name}</h2>
        <div class="products-container" id="category-${category.id}">
            ${createProductsHTML(category.products)}
        </div>
    `;
    return categoryDiv;
}

// Ürünleri HTML'e çeviren fonksiyon
function createProductsHTML(products) {
    return products.map(product => `
        <div class="product-card">
            <img src="${product.image}" alt="${product.name}" class="product-image">
            <div class="product-details">
                <h3>${product.name}</h3>
                <p>${product.description}</p>
                <span class="price">${product.price} TL</span>
            </div>
        </div>
    `).join('');
} 