var sizeMatrix = prompt("Введите размерность", "5");
document.write('<link rel="stylesheet" type="text/css" href="lab1.css"> '+'<table align="center" width="100%">');
for (i = 0; i < sizeMatrix; i++){
	document.write('<tr>');
	for (j = 0; j < sizeMatrix; j++){
		
		if ((i+j) % 2 == 0){
			document.write('<td class="odd">' + (i+1) + '_' + (j+1) + '</td>');
		} else{
			document.write('<td class="even">' + (i+1) + '_' + (j+1) + '</td>');
		}
		
	}
	document.write('</tr>' + "\n");
}
document.write('</table>')