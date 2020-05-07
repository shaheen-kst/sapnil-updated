$(document).ready(function(){
   let tA = $('.totalAmount');
   let nA = $('#NetAmount');
   let dA = $('#DueAmount');
   let pA = $('#PaidAmount');
   tA.on('focus',function(){
   //let framePrice = 0;
       //if($('#FramePrice').val() != ''){ framePrice = parseInt($('#FramePrice').val()); }
       let framePrice = $('#FramePrice').val() != '' ? parseInt($('#FramePrice').val()) : 0;
       let lensePrice = $('#PowerLensePrice').val() != '' ? parseInt($('#PowerLensePrice').val()) : 0;
       let contactLensePrice = $('#ContactLensePrice').val() != '' ? parseInt($('#ContactLensePrice').val()) : 0;
       tA.val(framePrice+lensePrice+contactLensePrice);
     console.log( framePrice);
   });
   // Net Amount
   nA.on('focus',function(){
      let totalAmount = parseInt(tA.val());
      let discountAmount = $('#DiscountAmount').val() != '' ?  parseInt($('#DiscountAmount').val()) : 0;
      console.log('disscount amount :'+discountAmount);
      if(discountAmount == 0) $('#DiscountAmount').val(0);
      nA.val(totalAmount - discountAmount);
      console.log(totalAmount - discountAmount);

   });
  // zeroing DueAmount after full payment

 
   //Due Amount
   dA.on('focus', function(){
        let paidAmount = $('#PaidAmount').val() != '' ? parseInt($('#PaidAmount').val()) : 0;
        if(paidAmount == 0) $('#PaidAmount').val(0);
        let netAmount = parseInt(nA.val());
        let dueAmount = netAmount - paidAmount;
        dA.val(dueAmount);
      
        
        console.log('Due Amount :'+dueAmount);
   });

   pA.on('blur', function(){
    zeroDueAmount();
   });
   $('#saleForm').on('submit', function(){
      zeroDueAmount();
   })


   function zeroDueAmount (){
      if(parseInt(nA.val()) == parseInt(pA.val())){
         dA.val(0);
      }
   }
});

