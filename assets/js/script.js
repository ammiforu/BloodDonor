$(function(){
    var photos = [
       
    'https://image-store.slidesharecdn.com/3771bd49-3d83-4ac6-8284-55cb4d4bb163-large.jpeg',
	'https://pbs.twimg.com/media/CtcOhRnWYAAcf01.jpg',
	    'http://ww1.hdnux.com/photos/34/74/26/7587232/3/1024x1024.jpg'

	];
	
	var slideshow = $('#slideShow').bubbleSlideshow(photos);

	$(window).load(function(){
		slideshow.autoAdvance(5000);
	});
	
	// Other valid method calls:
	
	// slideshow.showNext();
	// slideshow.showPrev();
	// slideshow.stopAutoAdvance();
});