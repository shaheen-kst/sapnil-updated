$(document).ready(function(){
    $('.date').datepicker
           (
               {
                 dateFormat : "yy-mm-dd",
                 changeMonth : true,
                 changeYear : true,
                 appendText : "",
                 yearRange : "2019:2025",
                 firstDay   : 6
                 
             }
           );  


           var availableTags = [
            "ActionScript",
            "AppleScript",
            "Asp",
            "BASIC",
            "C",
            "C++",
            "Clojure",
            "COBOL",
            "ColdFusion",
            "Erlang",
            "Fortran",
            "Groovy",
            "Haskell",
            "Java",
            "JavaScript",
            "Lisp",
            "Perl",
            "PHP",
            "Python",
            "Ruby",
            "Scala",
            "Scheme"
        ];
        $( "#auto" ).autocomplete({
            source: availableTags
        });
});