function changeDisplayById(id, value) {
	document.getElementById(id).style.display = value;
}
function nextRegPage(totalPages) {
	for(i = 1; i < totalPages; i++){
		if(document.getElementById('regp'+i).style.display = 'inline') {
			changeDisplayById('regp'+i, 'none');
			changeDisplayById('regp'+(i+1), 'inline');
			break;
		}
	}
}
function prevRegPage(totalPages) {
	for(i = totalPages; i > 1; i--) {
		if(document.getElementById('regp'+i).style.display = 'inline') {
			changeDisplayById('regp'+i, 'none');
			changeDisplayById('regp'+(i-1), 'inline');
			break;
		}
	}
}
