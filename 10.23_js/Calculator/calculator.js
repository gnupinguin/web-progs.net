window.onload = function(){
	var terminal = document.getElementById('terminal');
	var arg1, arg2, operation;
	arg1 = arg2 = operation = null;
	//var countDot = 0;



	var allButtons = document.getElementById('button').getElementsByTagName('td');
	for (var i = allButtons.length - 1; i >= 0; i--) {
		allButtons[i].onmouseover = function(event){
			event.currentTarget.style.backgroundColor="red";
		}

		allButtons[i].onmouseout = function(event){
			event.currentTarget.style.backgroundColor='black';
		}

		allButtons[i].onmousedown = function(event){
			event.currentTarget.style.borderColor = 'grey #E0E0E0 #E0E0E0 grey';
		}

		allButtons[i].onmouseup = function(event){
			event.currentTarget.style.borderColor = '#E0E0E0 grey grey #E0E0E0';
		}
	};



	var buttonNumbers = document.getElementsByClassName('number');
	for (var i = buttonNumbers.length - 1; i >= 0; i--) {
		buttonNumbers[i].onclick = function(event){
			var num = event.currentTarget.textContent;

			//if previous operation is '='
			if (arg1 === null ){
				terminal.value = "0";
				arg1 = 0;
			}
			//if user input two or more dots
			if(terminal.value.indexOf('.') != -1 && num == '.') return;

			
			terminal.value = (terminal.value != "0") ? terminal.value + num :
				(num != ".")? num : "0.";//bad codestyle, but I'm drunk

		};
	}

	

	document.getElementById('invert').onclick = function(){
		terminal.value = parseFloat(terminal.value) * (-1);
	};

	document.getElementById('sqrt').onclick = function(){
		terminal.value = Math.sqrt(parseFloat(terminal.value));
	};

	document.getElementById('clear').onclick = function(){
		terminal.value = "0";
		arg1 = arg2 = null;
		countDot = 0;
		operation = null;
	};

	var buttonBinaryFunctions = document.getElementsByClassName("binary");
	for (var i = buttonBinaryFunctions.length - 1; i >= 0; i--) {
		buttonBinaryFunctions[i].onclick = function(event){
			//if user make two click on binary operation without click '='
			if (operation != null){
				document.getElementById("result").onclick();
				operation = event.currentTarget.textContent;
			}
			arg1 = parseFloat(terminal.value);
			terminal.value = "0";
			operation = event.currentTarget.textContent;
		}
	};

	document.getElementById("result").onclick = function(){
		//.alert('Hello,World!');
		arg2 = parseFloat(terminal.value);
		switch (operation){
			case '+': terminal.value = arg1 + arg2; break;
			case '-': terminal.value = arg1 - arg2; break;
			case '*': terminal.value = arg1 * arg2; break;
			case '/': terminal.value = arg1 / arg2; break;
		}
		arg1 = arg2 = operation =null;
	};

	var stringForDiv = "BODY<br>";
	getTags(document.getElementsByTagName('body')[0],  "&emsp;");
	
	document.getElementsByTagName('div')[0].innerHTML = stringForDiv;

	function getTags(rootTag, spaces){
		var tags = rootTag.childNodes;
		if (tags.length == 1){
			return ;
		}
		for (var i = tags.length - 1; i >= 0; i--) {
			if (tags[i].tagName == undefined ) continue;
			stringForDiv += spaces + tags[i].tagName + '<br>';
		 	getTags(tags[i], spaces + "&emsp;");
		}
	}
	
};
