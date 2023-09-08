$(document).on('keyup', '#prsearch', function () {
    let url = window.location.href
    console.log()
    let val = $(this).val();
    if (val.trim().length > 3) {
        fetch(`${ url.split('/')[1] } / store / search ? name = ${ val }`)
            .then(res => {
                return res.text()
            }).then(data => {

                $('.prdsearch').html(data)
            })
    } else {
        fetch(`${ url.split('/')[1] } / store / search ? name =`)
            .then(res => {
                return res.text()
            }).then(data => {

                $('.prdsearch').html(data)
            })
    }
})