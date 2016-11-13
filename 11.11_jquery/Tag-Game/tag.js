$(document).ready(function(){
	var firstImage = null, secondImage = null;
	var images = ['url("images/1.jpg")', 'url("images/2.jpg")', 'url("images/3.jpg")', 'url("images/4.jpg")'];//css-images for game
	const min = 0, max = 3; // array bounds

	var countPermutation = 7;
	for (var i = countPermutation - 1; i >= 0; i--) {
		/*make two random numbers*/
		var firstRandIndex = Math.floor(Math.random()* (max - min + 1)) + min;
		var secondRandIndex = Math.floor(Math.random() * (max - min + 1)) + min;

		/*swap two random elements in array*/
		var tmp = images[firstRandIndex];
		images[firstRandIndex] = images[secondRandIndex];
		images[secondRandIndex] = tmp;
	}



	$("#d1,#d2,#d3,#d4").each(function(index){
		$(this).css("background-image", images[index]);

		$(this).click(function(){
			$(this).css("border-color", "red");
			if (firstImage === null){
				firstImage = this;
			}else{
				secondImage = this;
				var backgroudImage = $(firstImage).css("background-image");
				$(firstImage).css("background-image", $(secondImage).css("background-image"));
				$(secondImage).css("background-image", backgroudImage);

				$(firstImage).css("border-color", "blue");
				$(secondImage).css("border-color", "blue");

				firstImage = secondImage = null;

				var divArray = $("#d1,#d2,#d3,#d4");
				for (var i = divArray.length - 1; i >= 0; i--) {
					var imageName = $(divArray[i]).css("background-image");
					var divId = $(divArray[i]).attr('id').substr(1);//d1 -> 1, d3 -> 3, ...

					if (imageName.indexOf(`${divId}\.jpg`) == -1){//if № image != № div
						return;
					}	
				}
				alert("You win!");

				
			}

		});
	});
});