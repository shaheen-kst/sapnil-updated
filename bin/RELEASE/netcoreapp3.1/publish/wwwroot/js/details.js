$(document).ready(function(){
    $('.product').popover({  
        title:  setData,  
        html: true,  
        placement: 'right',
         
    });  
    function setData() {  
        var set_data = '';  
        var element = $(this);  
        var id =parseInt(element.attr("id"));  
        console.log(typeof id);
        $.ajax({  
           // url: "/Home/Details?id" + id,  
           url : "/Home/Details",
            method : 'get',
           // method: "post",  
            async: false,  
            data: { id: id },  
            success: function (data) {  
               // console.log(data);
                set_data = data;  
            }  
        });  
        return set_data;  
    }
    /* payment details */
    $('.payment').popover({  
        title:  setDataPayment,  
        html: true,  
        placement: 'right',
         
    });  
    function setDataPayment() {  
        let set_data = '';  
        let element = $(this);  
        let id = element.attr("id");  
        $.ajax({  
           // url: "/Home/Details?id" + id,  
           url : "/Home/PaymentDetails",
            method : 'get',
           // method: "post",  
            async: false,  
            data: { id: id },  
            success: function (data) {  
                console.log(data);
                set_data = data;  
            }  
        });  
        return set_data;  
    }
});