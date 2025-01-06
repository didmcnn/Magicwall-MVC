// Delete Model Function with SweetAlert
function DeleteModel(id, endpoint) {
    Swal.fire({
        title: 'Emin misiniz?',
        text: "Bu veriyi silmek istediğinizden emin misiniz?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, sil!',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {
            // If user confirms, send AJAX request
            $.ajax({
                url: '/Admin/' + endpoint, // Replace with your actual endpoint
                type: 'POST',
                data: { Id: id },
                success: function (response) {
                    table.row($(`a[onclick="DeleteModel(${id},'${endpoint}')"]`).parents('tr')).remove().draw();
                    Swal.fire(
                        'Silindi!',
                        'Veri başarıyla silindi.',
                        'success'
                    );
                    // Remove the deleted row from the table
                },
                error: function (xhr, status, error) {
                    Swal.fire(
                        'Hata!',
                        'Veri silinirken bir hata oluştu.',
                        'error'
                    );
                }
            });
        }
    });
}