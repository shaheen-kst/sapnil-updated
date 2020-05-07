$(document).ready(function(){
    let tCell = $('.cellNo');
    
    tCell.on('change',function(){
        let cellNo = tCell.val();
        if( cellNo !=null && cellNo.length == 11)
        {
         console.log(cellNo.length);
         $.ajax(
            {
                url      : '/Home/LastSale',
                method   : 'GET',
                data     : {cell : cellNo },
                dataType : 'json',
                cache    : false,
                contentType :"application/json, charset=utf-8",
                success  : function(data){
                   // console.log(typeof data);
                    if(data !=null)
                    {
                        console.log(typeof data);
                        let j = JSON.parse(data);
                        console.log(typeof j);
                        console.log(j);
                        console.log(data.Name);
                       
                           
                            /* $('#Name').val(j.Name);
                            $('#Address').val(j.Address);
                            let date = j.DeliveryDate.substring(0,10);
                            $('#DeliveryDate').val(date); */
                            populate(j);
                       

                    }
                    else { console.log('not found data')

                    }
                }
        });
    } //else {
      //  $( ":input" ).val("");

   // }
       
    
    });
   /*clear input field
    tCell.on('keyup',function(){
        if(tCell.val() !=null && tCell.val().length < 11){
            $( ":input" ).val("");
        }
    }); */

    function populate(j){
        $('#Name').val(j.Name);
        $('#Address').val(j.Address);
        let date = j.DeliveryDate.substring(0,10);
        $('#DeliveryDate').val(date);
        $('#FrameName').val(j.Product.FrameName)
        $('#FrameQty').val(j.Product.FrameQty)
        $('#FramePrice').val(j.Product.FramePrice)
        $('#PowerLense').val(''+j.Product.PowerLense+'')
      // $('#PowerLense').val("1")
        $('#PowerLenseQty').val(j.Product.PowerLenseQty)
        $('#PowerLensePrice').val(j.Product.PowerLensePrice)
        $('#ContactLense').val(''+j.Product.ContactLense+'')
        $('#ContactLenseQty').val(j.Product.ContactLenseQty)
        $('#ContactLensePrice').val(j.Product.ContactLensePrice)
        /* Power  */
        $('#LeftEyeSph').val(j.Product.LeftEyeSph)
        $('#LeftEyeCyl').val(j.Product.LeftEyeCyl)
        $('#LeftEyeAxis').val(j.Product.LeftEyeAxis)
        $('#LeftEyeAdd').val(j.Product.LeftEyeAdd)

        $('#RightEyeSph').val(j.Product.RightEyeSph)
        $('#RightEyeCyl').val(j.Product.RightEyeCyl)
        $('#RightEyeAxis').val(j.Product.RightEyeAxis)
        $('#RightEyeAdd').val(j.Product.RightEyeAdd)
        /* focal option */
        if(j.Product.FocalOption == 'bifocal'){
            $('#bifocal').prop('checked', true)
        }
        if(j.Product.FocalOption == 'unifocal'){
            $('#unifocal').prop('checked', true)
        }
        /* Delivery */
        if(j.Product.DeliveryStatus == 'Not-delivered'){
            $('#not').prop('checked', true)
        }
        if(j.Product.DeliveryStatus == 'Delivered'){
            $('#yes').prop('checked', true)
        }


    }
});