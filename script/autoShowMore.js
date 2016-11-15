window.onscroll = function () {
	if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
		var divShowMore = document.getElementById('showMore');
		if (divShowMore !== null) {
			divShowMore.click();
		}
	}
};
