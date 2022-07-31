/*Galeriqta shte e na nqkolko razdela  ediniq shte e s moi snimki, kato kato caknesh ediniq razdel shte ti otvarq prozorec kato predniq mi sait i tam shte mojesh da razglejdash
snimki kato album kato v damqnov house saita, kato cakna More na prednata stranica shte pre prehvarlq tam*/
/*v razdel dokumenti shte mogat da se svalqt razlichni dokumenti kato CVto mi, i proektite mi*/
/*vav foruma shte mogat da se pishat komentari i da se sortirat*/
/*v avtobiografiq shte napisha neshtko kratko za sebe si kade sam uchil, kakvi kursove sam minal, kakvi knigi cheta i hobita imam, shte vidq tozi razdel moje i da go nqma
i da si ostane prosto parvata stranica i da gi dovabq tam tezi neshta*/

//when nav is clicked, make navbar apper and move the home page image
function myFunction() {
        var x = document.getElementById("myTopnav");
        var y = document.getElementById("main-img");
            
        if (x.className === "topnav") {
              x.className += " responsive";
              y.className += " move"
            
            } else {
              x.className = "topnav";
              y.className = "myImage"
            }
          }

//THIAT

//Global variable
var z = 0;
var slideIndex = 1;
//Modal using id of the modal, image to activate the modal and the index of the modal to close it
function modalit(id, image, index) {
    // Get the modal
console.log("Index:" + index);
var modal = document.getElementById(id);

// Get the button that opens the modal
var btn = document.getElementById(image);

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[index];
var span2 = document.getElementsByClassName("close2")[index];

// When the user clicks the button, open the modal 
btn.onclick = function() {
  modal.style.display = "block";
  //Global variable equals the index of the modal + 1
  z = index+1;
  //When the users open the modal, always start from the first slide
  slideIndex = 1;
  showSlides(slideIndex);
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
  modal.style.display = "none";
}
span2.onclick = function() {
  modal.style.display = "none";
}
// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}

}


$(document).ready(function(){ 
  
  //Change opacity of main when the icon is clicked(for smaller devices) - works only on home page
  $(".icon").on("click", function() {
      
    //click equals the amount of clicks made or 0 if none are made
      var click = $(this).data('clicks') || 0;
      //If clicked again bring opacity back to normal
      if (click % 2 == 1) {
        $("main").css("opacity", "1");
        //alert("ENTER ODD");
      }
      //On click lower opacity
      else {
        $("main").css("opacity", "0.5");
        //alert("ENTER EVEN");
      };
      //increase clicks
      $(this).data('clicks',click+1);
  });


}); 