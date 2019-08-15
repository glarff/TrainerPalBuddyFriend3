/*
   TrainerPalBuddyFriend project
   Written By: Michael Ross
   Date: 1/4/19
*/

/* ======================= GLOBAL JQUERY ========================= */

$(document).ready(function () {
    $('input[type!="submit"]').each(function () {
        $(this).prop('readonly', true);
        $(this).css('background-color', '#000');
        $(this).css('color', '#D3D3D3');
    })

    $('textarea').each(function () {
        $(this).prop('readonly', true);
        $(this).css('background-color', '#000');
        $(this).css('color', '#D3D3D3');
        $(this).height(30);
    })
});

$(document).on('click', 'button.deletebtn', function () {
    $(this).closest('tr').hide();
    $(this).parent().siblings('.pk').children().val(0);
});

$(document).on('click', 'button.editbtn', function () {

    if ($(this).html() == 'Edit') {
        $(this).parent().siblings().children('input[type="text"]').prop('readonly', false);
        $(this).parent().siblings().children('input[type!="submit"]').css('background-color', '#fff');
        $(this).parent().siblings().children('input[type!="submit"]').css('color', '#000');
        $(this).parent().siblings().children('textarea').prop('readonly', false);
        $(this).parent().siblings().children('textarea').css('background-color', '#fff');
        $(this).parent().siblings().children('textarea').css('color', '#000');
        $(this).html('Save');
    }
    else {
        $(this).parent().siblings().children('input[type="text"]').prop('readonly', true);
        $(this).parent().siblings().children('input[type!="submit"]').css('background-color', '#000');
        $(this).parent().siblings().children('input[type!="submit"]').css('color', '#fff');
        $(this).parent().siblings().children('textarea').prop('readonly', true);
        $(this).parent().siblings().children('textarea').css('background-color', '#000');
        $(this).parent().siblings().children('textarea').css('color', '#D3D3D3');
        $(this).html('Edit');
    }
});

$(document).on('click', 'button.btnStartTimer', function () {
    if ($(this).html() == 'Start') {
        execute();
        $(this).html('Pause');
    }
    else {
        $(this).html('Resume');
    }
});

$(document).on('click', '#zAddBtn', function () {
    $('.hiddenRow:first').addClass('visibleRow');
    $('.hiddenRow:first').children(".pk").children().val(-1);
    $('.hiddenRow:first').find('input[type="text"]').prop('readonly', false);
    $('.hiddenRow:first').find('input[type="text"]').css('background-color', 'white');
    $('.hiddenRow:first').find('input[type="text"]').css('color', '#000');
    $('.hiddenRow:first').find('textarea').prop('readonly', false);
    $('.hiddenRow:first').find('textarea').css('background-color', 'white');
    $('.hiddenRow:first').find('textarea').css('color', '#000');
    $('.hiddenRow:first').find('.editbtn').html('Save');
    $('.hiddenRow:first').removeClass('hiddenRow');
});

/* =============================================================== */

/* ======================= UTIL FUNCTIONS ======================== */

Date.prototype.addMilliseconds = function(ms) {    
   this.setTime(this.getTime() + ms); 
   return this;   
}

Date.prototype.subtractMilliseconds = function(ms) {    
   this.setTime(this.getTime() - ms); 
   return this;   
}

function changeColor(id,clr) { 
   document.getElementById(id).style.backgroundColor = clr; 
}

function changeText(id,txt) { 
   document.getElementById(id).innerHTML = txt; 
}

function getColor(id) { 
   return document.getElementById(id).style.backgroundColor;
}

function getText(id) { 
   return document.getElementById(id).innerHTML; 
}
   
function getColorByIntensity(intsty) {

   if (intsty < 2) { return"#006400"; } // 1 - dark green   
   else if (intsty < 3) { return"#32CD32"; } // 2 - lime green   
   else if (intsty < 4) { return"#FF8C00"; }  // 3 - dark orange
   else if (intsty < 5) { return"#FA8072"; }  // 4 - salmon
   else { return"#B22222"; }  // 5 - firebrick

}

function changeBorder(intsty) {

   elements = document.getElementsByClassName("segmentTitleContainer");
   elements2 = document.getElementsByClassName("mainComponentContainer");

   newColor = "2px solid " + getColorByIntensity(intsty);

   for (var i = 0; i < elements.length; i++) {
      elements[i].style.border = newColor;
   }

   for (var i = 0; i < elements2.length; i++) {
      elements2[i].style.border = newColor;
   }

}

function addZeroPadding(num) {
   if (num < 10) return "0" + num;
   return num;
}

/* =============================================================== */

/* ====================== HELPER FUNCTIONS ======================= */

/*
   Get Time Divisions
   Inputs: a value in miliseconds
   Returns: an object with properties containing the hours, minutes,
      and seconds divisions of the provided value.
*/
function getTimeDivisions(ms) {

   var divs = { };

   divs.hrs = Math.floor((ms % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
   divs.mins = Math.floor((ms % (1000 * 60 * 60)) / (1000 * 60));
   divs.secs = Math.floor((ms % (1000 * 60)) / 1000);

   return divs;
}

/*
   Get Time Divisions 2
   Inputs: a value in miliseconds
   Returns: an object with properties containing the minutes and seconds 
      divisions of the provided value.
*/
function getTimeDivisions2(ms) {

   var divs = { };

   divs.mins = Math.floor((ms % (1000 * 60 * 60)) / (1000 * 60));
   divs.secs = Math.floor((ms % (1000 * 60)) / 1000);

   return divs;
}

function formatForTimer(hrs,mins,secs) {

   timerStr = "";

   // Hours
   if (hrs > 0) {
       timerStr += hrs;
       timerStr += ":";
   }

   // Minutes
   if (hrs > 0) {
      timerStr += addZeroPadding(mins);
   }
   else {
      if (mins > 0) {
         timerStr+=mins;
      }
   }

   // Seconds
   timerStr += ":";
   timerStr += addZeroPadding(secs);

   return timerStr;

}

/*
   Format For Timer 2
   Inputs: Total time, start time of segment, duration of segment 
   Returns: An object containing the hrs, mins, and secs 
      broken up into properties for the start and end times of the
      provided segment.
*/
function formatForTimer2(ms) {

   timerStr = "";

   divs = getTimeDivisions(ms);

   tmrHrs = divs.hrs;
   tmrMins = divs.mins;
   tmrSecs = divs.secs;

   // Hours
   if (tmrHrs > 0) {
       timerStr += tmrHrs;
       timerStr += ":";
   }

   // Minutes
   if (tmrHrs > 0) {
      timerStr += addZeroPadding(tmrMins);
   }

   else {
      if (tmrMins > 0) {
         timerStr=tmrMins;
      }
   }

   // Seconds
   timerStr += ":";
   timerStr += addZeroPadding(tmrSecs);

   return timerStr;

}

/*
   Calculate Next Segment Times
   Inputs: Total time, start time of segment, duration of segment 
   Returns: An object containing the hrs, mins, and secs 
      broken up into properties for the start and end times of the
      provided segment.
*/
   function calculateNextSegmentTimes(ttl, strt, dur) {

      var x = { };

      strtDivs = getTimeDivisions(ttl - strt);
      endDivs = getTimeDivisions(ttl - (strt + dur));
      
      x.hrs1 = strtDivs.hrs;
      x.mins1 = strtDivs.mins;
      x.secs1 = strtDivs.secs;

      x.hrs2 = endDivs.hrs;
      x.mins2 = endDivs.mins;
      x.secs2 = endDivs.secs;

      return x;
   }

/*
   Calculate Next Segment Window
   Inputs: Total time of workout, elapsedDuration, and duration of the segment 
   Returns: A formatted string showing the timing of the segment window
*/
function calculateSegmentWindow(ttl, strt, dur) {

   var win = calculateNextSegmentTimes(ttl,strt,dur);

   nextHours1 = win.hrs1;
   nextMinutes1 = win.mins1;
   nextSeconds1 = win.secs1;

   nextHours2 = win.hrs2;
   nextMinutes2 = win.mins2;
   nextSeconds2 = win.secs2;

   segWin = "";

   // Window Start Time
   if (nextHours1 > 0) {
      segWin += nextHours1;
      segWin += ":";
      segWin += addZeroPadding(nextMinutes1);
   }

   else {
      segWin += nextMinutes1;
   }

   segWin += ":";
   segWin += addZeroPadding(nextSeconds1)

   segWin += " - ";

   // Window End Time
   if (nextHours2 > 0) {
      segWin += nextHours2;
      segWin += ":";
      segWin += addZeroPadding(nextMinutes2);
   }

   else {
      segWin += nextMinutes2;
   }

   segWin += ":";
   segWin += addZeroPadding(nextSeconds2)

   return segWin;
}

/*
   Calculate Total Time
   Inputs: workout object
   Returns: the total duration of the workout
*/
function calculateTotalTime(wk) {
 
   ttl = 0;

   for (i = 0; i < wk.segments.length; i++) {
      ttl += wk.segments[i].duration;
   }

   return ttl;
}

/*
   Update Upcoming Segments
   Inputs: workout object, current segment
   Action: updates the upcoming segments graphic
*/
function updateUpcomingSegments(wk, ttl, seg) {

   segmentsRemaining = (wk.segments.length - seg - 1);

   // If there's more than 4 segments remaining, shift the elements 2-5 up
   if (wk.segments.length - seg >= 6) {

      for (i = 0; i < 4; i++) {

         // Update Segment Window
         text1 = "upcomingSegment" + (i+1) + "window";
         text2 = "upcomingSegment" + (i+2) + "window";
         changeText(text1, getText(text2));

         // Update Segment Title
         text1 = text1.replace("window", "title");
         text2 = text2.replace("window", "title");
         changeText(text1, getText(text2));

         // Update Segment Intensity
         text1 = text1.replace("title", "intensity");
         text2 = text2.replace("title", "intensity");
         changeText(text1, getText(text2));
         changeColor(text1, getColor(text2));

      }

      // Calculate 5th segment
      elapsedDuration = 0;
      for (i = 0; i < seg + 5; i++) {
         elapsedDuration += wk.segments[i].duration;
      }

      nextSegmentWindow = "";
      nextSegmentWindow = calculateSegmentWindow(ttl, elapsedDuration, 
         wk.segments[seg + 5].duration);

      // Update 5th segment components
      text1 = "upcomingSegment5"
      changeText(text1 + "window", nextSegmentWindow);
      changeText(text1 + "title", wk.segments[seg + 5].title);
      changeText(text1 + "intensity", wk.segments[seg + 5].intensity);
      changeColor(text1 + "intensity", 
         getColorByIntensity(wk.segments[seg + 5].intensity));
      
   }

   // if <5 segments remaining, blank out the last one and shift up
   else {  

      for (i = 0; i < 4; i++) {

         changeText("upcomingSegment" + (i+1) + "window", 
            getText("upcomingSegment" + (i+2) + "window"));

         changeText("upcomingSegment" + (i+1) + "title", 
            getText("upcomingSegment" + (i+2) + "title"));

         changeText("upcomingSegment" + (i+1) + "intensity", 
            getText("upcomingSegment" + (i+2) + "intensity"));

         changeColor("upcomingSegment" + (i+1) + "intensity", 
            getColor("upcomingSegment" + (i+2) + "intensity"));
      }

      changeText("upcomingSegment5window", "");
      changeText("upcomingSegment5title", "");
      changeText("upcomingSegment5intensity", "");
      changeColor("upcomingSegment5intensity", "black");
      
   }

}

/* =============================================================== */

