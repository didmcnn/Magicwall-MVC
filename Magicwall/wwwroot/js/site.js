// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Dil Çeviri
function changeLanguage() {
    const flagIcon = document.getElementById('flagIcon');
    const currentFlag = flagIcon.src;

    // Bayrağa flip animasyonu ekle
    flagIcon.classList.add('flip');

    // 0.25 saniyede (flip'in yarısında) bayrağı değiştir
    setTimeout(() => {
        if (currentFlag.includes('tr.svg')) {
            flagIcon.src = "https://cdnjs.cloudflare.com/ajax/libs/flag-icon-css/3.4.6/flags/4x3/gb.svg";
            flagIcon.alt = "English";
        } else {
            flagIcon.src = "https://cdnjs.cloudflare.com/ajax/libs/flag-icon-css/3.4.6/flags/4x3/tr.svg";
            flagIcon.alt = "Türkçe";
        }

        // 0.5 saniye sonra (animasyon bitince) flip sınıfını kaldır
        flagIcon.classList.remove('flip');
    }, 250);
}
//End Dil Çeviri


//Foto Galeri
document.addEventListener("DOMContentLoaded", function () {
    const galleryCards = document.querySelectorAll('.gallery-card');

    function handleScroll() {
        galleryCards.forEach(card => {
            const cardPosition = card.getBoundingClientRect().top;
            const windowHeight = window.innerHeight;

            // Kart pencerenin alt kısmına geldiğinde animasyonu tetikleyelim
            if (cardPosition < windowHeight - 100) {
                card.classList.add('slide-in');
            }
        });
    }

    // Scroll olayında handleScroll fonksiyonu çalışsın
    window.addEventListener('scroll', handleScroll);

    // Sayfa yüklenince de kontrol edilsin (sayfa başında animasyonlar tetiklensin)
    handleScroll();
});

//End Foto Galeri


//Video Galeri
document.addEventListener("DOMContentLoaded", function () {
    const videos = document.querySelectorAll(".video-container video");
    const overlays = document.querySelectorAll(".video-container .overlay");

    videos.forEach((video, index) => {
        // Fare video üzerine geldiğinde video oynasın ve overlay kaybolsun
        video.addEventListener("mouseenter", function () {
            if (video.paused) { // Video duruyorsa (pause'daysa)
                video.muted = true;  // Ses olmadan oynatılması garanti olsun
                video.play(); // Hover ile video oynat
                overlays[index].style.opacity = "0"; // Video oynarken overlay'i gizle
            }
        });

        // Fare video üzerinden ayrıldığında video dursun ve overlay geri gelsin
        video.addEventListener("mouseleave", function () {
            video.pause(); // Fare dışına çıkınca videoyu durdur
            overlays[index].style.opacity = "1"; // Video durduğunda overlay tekrar görünür olsun
        });

        // Video tıklanınca oynasın ve overlay kaybolsun
        overlays[index].addEventListener("click", function () {
            if (video.paused) { // Eğer video duruyorsa (pause'daysa)
                video.muted = true; // Ses olmadan oynatılması garanti olsun
                video.play(); // Tıklayınca video oynat
                this.style.opacity = "0"; // Overlay tıklayınca kaybolsun
            } else {
                video.pause(); // Eğer oynuyorsa tıklanınca durdur
                this.style.opacity = "1"; // Durdurulduğunda overlay geri gelsin
            }
        });

        // Video bittiğinde overlay geri gelsin
        video.addEventListener("ended", function () {
            overlays[index].style.opacity = "1"; // Video bitince overlay tekrar gelsin
        });
    });
});
//End Video Galeri



//Referansalar
document.addEventListener("scroll", function() {
    const cards = document.querySelectorAll('.section-references .card');
    const windowHeight = window.innerHeight;

    cards.forEach(card => {
        const cardPosition = card.getBoundingClientRect().top;

        if (cardPosition < windowHeight - 100) {
            card.classList.add('show'); // Kart görünür hale gelir
        }
    });
});
//End Referansalar




//Banka Bilgileri Kopyalama
document.querySelectorAll('.copy-icon').forEach(icon => {
    icon.addEventListener('click', function() {
        const targetId = this.getAttribute('data-target');
        const textToCopy = document.getElementById(targetId).textContent;

        // Texti kopyalamak için geçici bir textarea oluşturuyoruz
        const textarea = document.createElement('textarea');
        textarea.value = textToCopy;
        document.body.appendChild(textarea);
        textarea.select();
        document.execCommand('copy');
        document.body.removeChild(textarea);

        // Kullanıcıya kopyalandığını gösteren bir mesaj
        alert('Kopyalandı: ' + textToCopy);
    });
});
//End Banka Bilgileri Kopyalama

