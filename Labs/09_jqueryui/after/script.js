$(function(){

	// accordion
	$("#accordion").accordion(
		{
			icons: {
				header: "ui-icon-circle-triangle-e",
				headerSelected: "ui-icon-circle-triangle-s"
			},
			collapsible: true,
			active: 1
		}
	);
	
	// autocomplete
	$("#technology").autocomplete(
		{
			source: ["Windows", "Windows Phone", "Apple OS/X", "All", "Android", "iOS"],
			minLength: 2	
		}
	);	
	
	// buttons
	$("#buttons").children().each(function(){
		$(this).button();
	});
    $("#radios").buttonset();
    $("#checks").buttonset();

	// datepicker
	$("#theDate").datepicker({
		minDate: new Date(2011, 1-1, 1),
		changeYear: true
	}); 
	
	// dialog
	$("#dialog").dialog(
		{
			autoOpen:false, 
			buttons: 
			{ 
				"Ok": function(event, ui){
					$(this).dialog("close");
				}
			}
		}
	);
	$("#dialogOpen").click(function(){
		$("#dialog").dialog("open")
	});

	// progressbar
	$("#progress").progressbar({value:0});
	
	var intervalId = setInterval(makeProgress, 200);
	
	function makeProgress(){
		var value = $("#progress").progressbar("value");
		if(value == 100){
			clearInterval(intervalId);
		}else{
			$("#progress").progressbar("value", ++value);
		}
	}
	
	// slider
	$("#slider").slider(
		{
			change: function(event, ui){
				$("#sliderValue").text(ui.value);
			}
		}	
	);
	
	// tabs
	$("#tabs").tabs({event:"mouseover"});
	
	// draggable
	$("#draggable").draggable({axis:"x"});

	// droppable
	$("#droppable").draggable({revert:"invalid"});
	$("#d1").droppable({accept: "h1", drop: onDrop });
	$("#d2").droppable({accept: "h1", drop: onDrop });
	
	function onDrop(event, ui){
		$(this).css({"background-color" : "white"});
	}
});