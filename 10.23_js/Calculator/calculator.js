window.onload = function(){
	var terminal = document.getElementById('terminal');
	var arg1, arg2, operation;
	arg1 = arg2 = operation = null;
	var countDot = 0;



	var allButtons = document.getElementsByClassName('button');
	for (var i = allButtons.length - 1; i >= 0; i--) {
		allButtons[i].onmouseover = function(event){
			event.currentTarget.style.backgroundColor="red";
		}

		allButtons[i].onmouseout = function(event){
			event.currentTarget.style.backgroundColor='#00BFFF';
		}

		allButtons[i].onmousedown = function(event){
			event.currentTarget.style.borderColor = 'grey #E0E0E0 #E0E0E0 grey';
		}

		allButtons[i].onmouseup = function(event){
			event.currentTarget.style.borderColor = '#E0E0E0 grey grey #E0E0E0';
		}
	}



	var buttonNumbers = document.getElementsByClassName('number');
	for (var i = buttonNumbers.length - 1; i >= 0; i--) {
		buttonNumbers[i].onclick = function(event){

			//if previous operation is =
			if (arg1 === null){
				terminal.value = "0";
				arg1 = 0;
			}

			var num = event.currentTarget.textContent;

			if (num == "."){
				countDot++;
			}

			//if user input two or more dots
			if(countDot > 1 && num == ".") return;

			
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
	};

	var buttonBinaryFunctions = document.getElementsByClassName("binary");
	for (var i = buttonBinaryFunctions.length - 1; i >= 0; i--) {
		buttonBinaryFunctions[i].onclick = function(event){
			arg1 = parseFloat(terminal.value);
			terminal.value = "0";
			countDot = 0;
			operation = event.currentTarget.textContent;
		}
	};

	document.getElementById("result").onclick = function(){
		arg2 = parseFloat(terminal.value);
		switch (operation){
			case '+': terminal.value = arg1 + arg2; break;
			case '-': terminal.value = arg1 - arg2; break;
			case '*': terminal.value = arg1 * arg2; break;
			case '/': terminal.value = arg1 / arg2; break;
		}
		arg1 = arg2 = operation =null;
		countDot = 0;
	};

};