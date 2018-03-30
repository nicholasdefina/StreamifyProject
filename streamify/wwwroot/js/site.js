$( document ).ready(function(){
    /**
    * JQuery code to re-route search method results
    * first search field populated and then button clicked,
    * the value in the search field is stored as var to concat with desired route
    */
    $( "button#searchArtist" ).click(function() {
        var search = $( "input#searchArtist" ).val();  
        window.location.href = '/GetArtist/' + search;
    });

    $( "button#searchAlbum" ).click(function() {
        var search = $( "input#searchAlbum" ).val();  
        window.location.href = '/GetAlbum/' + search;
    });

    $( "button#searchTrack" ).click(function() {
        var search = $( "input#searchTrack" ).val();  
        window.location.href = '/GetTrack/' + search;
    });


    $( "button#addtrack" ).click(function() {
        var search = $( "input#getinfo" ).val();  
        window.location.href = '/addtrack/' + search;
    });


});