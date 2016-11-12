$(document).ready(function(){
	var firstImage = null, secondImage = null;
	$("#d1,#d2,#d3,#d4").each(function(){
		$(this).click(function(){
			$(this).css("border-color", "red");
			if (firstImage === null){
				firstImage = this;
			}else{
				secondImage = this;
				var backgroudImage = $(firstImage).css("background-image");
				$(firstImage).css("background-image", $(secondImage).css("background-image"));
				$(secondImage).css("background-image", backgroudImage);

				$(firstImage).css("border-color", "blue")
				$(secondImage).css("border-color", "blue")

				firstImage = secondImage = null;
			}

		});
	});
});