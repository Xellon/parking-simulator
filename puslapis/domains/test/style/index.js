function scrollToOne(amount){
	var max_amount = 200;
	if (amount>max_amount)
		amount=max_amount;
	return amount/max_amount;
}

$(window).scroll(function() {
	var scroll_amount = $(window).scrollTop();
	console.log(scroll_amount);
	if (scroll_amount > 0) {
		$(".toolbar").css("background-color","rgba(0, 120, 255, "+scrollToOne(scroll_amount)*0.7+")");
		$(".toolbar_title").css("opacity",scrollToOne(scroll_amount));
	}
	else{
		$(".toolbar").css("background-color","rgba(0, 120, 255, 0)");
		$(".toolbar_title").css("opacity","0");
	}
});