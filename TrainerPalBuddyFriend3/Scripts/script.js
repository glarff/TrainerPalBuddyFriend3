/*
   TrainerPalBuddyFriend project
   Written By: Michael Ross
   Date: 1/4/19
*/

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

   newColor = "5px solid " + getColorByIntensity(intsty);

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

/* ======================== MAIN PROGRAM ========================= */

function loadElements() {

   // Calculate total duration of all segments
   totalTime = calculateTotalTime(w1);

   // Initial population of next segments list
   elapsedDuration = 0;

   for (i = 0; i < 5; i++) {
      
      nextSegmentWindow = calculateSegmentWindow(totalTime, elapsedDuration, 
         w1.segments[i].duration);

      changeText("upcomingSegment" + (i+1) + "intensity", 
         w1.segments[i].intensity);

      changeColor("upcomingSegment" + (i+1) + "intensity",
         getColorByIntensity(w1.segments[i].intensity));

      changeText("upcomingSegment" + (i+1) + "window", nextSegmentWindow);
      changeText("upcomingSegment" + (i+1) + "title", w1.segments[i].title);

      elapsedDuration += w1.segments[i].duration;

   }

   // Set the Workout Title
   changeText("workoutTitle", w1.title);

   // Display the first segment
   changeText("segmentTitle", w1.segments[0].title);
   changeText("segmentTips", w1.segments[0].tips);

   // Initial population of timers
   changeText("mainTimer", formatForTimer2(totalTime));

   changeText("segmentTimer", formatForTimer2(w1.segments[0].duration));
   changeBorder(w1.segments[0].intensity);

}

function execute() {

   // Calculate total time and time left after semgment 1
   totalTime = calculateTotalTime(w1);
   timeRemainingAfterCurrentSegment = totalTime - w1.segments[0].duration;

   // Set the date/time we're counting down to
   finishTime = new Date().addMilliseconds(totalTime);
   currentSegment = 0;
   elapsedDuration = 0;

   // Shift down in upcoming segments
   updateUpcomingSegments(w1,totalTime,0);

   // Start loop - iterate every .1 seconds
   x = setInterval(function() {

      // Get todays date and time
      now = new Date().getTime();

      // Find the distance between now and the count down date
      distance = finishTime - now;
      distance2 = distance - timeRemainingAfterCurrentSegment;

      mainTimerDivs = getTimeDivisions(distance);
      segTimerDivs = getTimeDivisions2(distance2);
        
      mainTimerHours = mainTimerDivs.hrs;
      mainTimerMinutes = mainTimerDivs.mins;
      mainTimerSeconds = mainTimerDivs.secs;

      segTimerMinutes = segTimerDivs.mins;
      segTimerSeconds = segTimerDivs.secs;

      // Display the main timer
      changeText("mainTimer", formatForTimer(mainTimerHours,mainTimerMinutes,
         mainTimerSeconds));

      // Display segment timer - use00 if negative
      if (segTimerSeconds < 0) {
           changeText("segmentTimer", formatForTimer(0,0,0));
      }

      else {
         changeText("segmentTimer", formatForTimer(0,segTimerMinutes,
            segTimerSeconds));
      }

      // Set component backgrounds based on intensity
      if (currentSegment < w1.segments.length) {
         changeBorder(w1.segments[currentSegment].intensity);
      }

      // When reaching end of the timer
      if (distance < 0) {
         clearInterval(x);
         changeText("mainTimer", "Done!");
         changeText("segmentTimer", "Done!");
      }

      // When rearching the end of a segment
      else if (distance2 < 0) {
            
         currentSegment++;

         // Recalculate time remaining after this segment
         timeRemainingAfterCurrentSegment = totalTime;

         for (i = 0; i < currentSegment + 1; i++) {
            timeRemainingAfterCurrentSegment -= w1.segments[i].duration;
         }

         // Update the labels on the screen
         changeText("segmentTitle", w1.segments[currentSegment].title);
         changeText("segmentTips", w1.segments[currentSegment].tips);

         // Update the next segments list
         updateUpcomingSegments(w1,totalTime,currentSegment);
      }

   }, 100);

}

/* ============================= FIN ============================= */