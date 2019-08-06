/*
   TrainerPalBuddyFriend project
   Written By: Michael Ross
   Date: 1/4/19
*/

// ============================= Constructors ============================== //

function newSegment(ttl, dur, int, tps) {

    var x = {};
    x.title = ttl;
    x.duration = dur;
    x.intensity = int;
    x.tips = tps;

    return x;
}

function newWorkout(ttl, dsc, tps, segs) {

    var x = {};
    x.title = ttl;
    x.description = dsc
    x.tips = tps;
    x.segments = segs;

    return x;

}

// ========================================================================= //

// ======================== Random Tip Generation ========================== //

function getTipByType(typ) {

    var possibilities = [];

    if (typ == "Biking") {

        possibilities.push("Think about pedaling as if tracing a square.  Push forward along the top, down the frontside, scrape the bottom, then pull back up the backside.");
        possibilities.push("Avoid side to side movement in the knees by keeping core tight - no Gumby riding.");
        possibilities.push("Dont let your pelvis slouch. Rotate the hips forward and push the butt back, similar to plank.");
        possibilities.push("Keep the grip on the bars relaxed.  No white knuckles!  Change grips often if needed.");
        possibilities.push("Pay attention!  Are all parts of your form good?  Let go of unneeded thoughts and focus on finishing the effort.");
        possibilities.push("Get on the pedals early - start pushing forward before 12 oclock position.  Feet flat or toes slightly pointed up.");
        possibilities.push("Keep your head up, relax your elbows, shoulders, and hands slightly.");

        return possibilities[Math.floor(Math.random() * possibilities.length)];
    }

    else if (typ == "Productivity") {

        possibilities.push("Focus on one goal at a time.  You have all this time to do this one task!");
        possibilities.push("If you get distracted by something, note down to do it later, rather than doing it now.");
        possibilities.push("Take short breaks if needed to clear your mind and rest, but dont start something else.");
        possibilities.push("Before starting something new, quickly think about what the most effecient way to execute it is, then go. Dont overthink it.");
        possibilities.push("Finish your task completely.  If theres time left, take a quick break and relax before the next segment.");

        return possibilities[Math.floor(Math.random() * possibilities.length)];
    }

    else if (typ == "FoamRoll") {

        possibilities.push("Move up and down the roll for five to ten reps, holding at the end of each move for a few seconds, then switch sides and repeat.");
        possibilities.push("When you hit a tight spot that is painful or uncomfortable, HOLD on that spot for 30-45 seconds. You should feel the tension release slowly");
        possibilities.push("Make sure to keep breathing, even when its painful. Holding your breath wont allow the muscles to release and relax.");
        possibilities.push("RELAX the muscle as best you can. If you are flexing or tensing the muscle group you are trying to roll out, you wont feel the trigger points you need to release");

        return possibilities[Math.floor(Math.random() * possibilities.length)];
    }

}

// ========================================================================= //


function getWorkout(wkid) {

    // ======================== 20 min preparation ========================= //

    var prep1s1 = newSegment("Set up bike", 300000, 1, "Make sure tires are " +
        "pumped up, trainer is clean and working well.");

    var prep1s2 = newSegment("Clean up", 300000, 1, "Clean up the area around " +
        "the bike and the desk. Get displays set.");

    var prep1s3 = newSegment("Put on gear", 300000, 1, "Start putting on your " +
        "gear.");

    var prep1s4 = newSegment("Get Ready", 300000, 1, "Use remaining time to do " +
        "some light stretching and breathing exercies.");

    var prep1 = [prep1s1, prep1s2, prep1s3, prep1s4];

    // ===================================================================== //

    // =========================== Wu-Ti warm up =========================== //

    var warmUp1s1 = newSegment("Get on the bike", 30000, 1, "Get on the bike " +
        "and get ready to go.");

    var warmUp1s2 = newSegment("Warm Up: Z1", 300000, 1, "Spend the first 5 " +
        "minutes of your session in Z1. Gradually increase cadence to 90+.");

    var warmUp1s3 = newSegment("Warm Up: Z2-Z3", 300000, 2, "Spend the next " +
        "5 minutes progressing through Z2. End at a low Z3.");

    var warmUp1s4 = newSegment("Warm Up: Max Spin / Easy Spin", 120000, 2,
        "Now increase the cadence to your maximum, hold for 5 seconds, " +
        "followed by 25 seconds easy spin. Repeat maximum cadence / easy " +
        "spin 3 more times.");

    var warmUp1s5 = newSegment("Warm Up: Easy Spin", 120000, 1, "Finish with " +
        " 2 minute easy spin before starting main content of session.");

    var warmUp1 = [warmUp1s1, warmUp1s2, warmUp1s3, warmUp1s4, warmUp1s5];

    // ===================================================================== //

    // ========================== 20 min warm up =========================== //

    var warmUp2s1 = newSegment("Get on the bike", 27000, 1, "Get on the bike " +
        "and get ready to go.");

    var warmUp2s2 = newSegment("90 RPM", 300000, 1, "Smooth pedaling - clear " +
        "your mind and mentally prepare for the upcoming session.");

    var warmUp2s3 = newSegment("95 RPM", 120000, 1, "Smooth pedaling - clear " +
        "your mind and mentally prepare for the upcoming session.");

    var warmUp2s4 = newSegment("100 RPM", 120000, 2, "Smooth pedaling - clear " +
        "your mind and mentally prepare for the upcoming session.");

    var warmUp2s5 = newSegment("105 RPM", 120000, 2, "Smooth pedaling - clear " +
        "your mind and mentally prepare for the upcoming session.");

    var warmUp2s6 = newSegment("110 RPM", 90000, 3, "Smooth pedaling - clear " +
        "your mind and mentally prepare for the upcoming session.");

    var warmUp2s7 = newSegment("120-130 RPM", 30000, 4, "Smooth pedaling - " +
        "clear your mind and mentally prepare for the upcoming session.");

    var warmUp2s8 = newSegment("90 RPM", 120000, 1, "Smooth pedaling - clear " +
        "your mind and mentally prepare for the upcoming session.");

    var warmUp2s9 = newSegment("MAX", 6000, 5, "Smooth pedaling - clear your " +
        "mind and mentally prepare for the upcoming session.");

    var warmUp2s10 = newSegment("90 RPM", 60000, 1, "Smooth pedaling - clear " +
        "your mind and mentally prepare for the upcoming session.");

    var warmUp2s11 = newSegment("90 RPM", 165000, 1, "Smooth pedaling - clear " +
        "your mind and mentally prepare for the upcoming session.");

    var warmUp2 = [warmUp2s1, warmUp2s2, warmUp2s3, warmUp2s4, warmUp2s5,
        warmUp2s6, warmUp2s7, warmUp2s8, warmUp2s9, warmUp2s10, warmUp2s9,
        warmUp2s10, warmUp2s9, warmUp2s11];

    // ===================================================================== //

    // ====================== Threshold Test Workout ======================= //

    // Segments 
    var w1s1 = newSegment("Threshold Test - First 10", 600000, 4, "Try to " +
        "maintain a pace that is challenging but can be maintained evenly for " +
        "30 minutes. Aim for a cadence of 90-100 rpm. Start recording heart " +
        "rate at the end of this session.");

    var w1s2 = newSegment("Threshold Test - Last 20", 1200000, 4, "Maintain " +
        "cadence of 90-100 rpm.  Keep good posture and form.  Give it a good " +
        "effort at that end, though leave enough energy to cool down.");

    var w1s3 = newSegment("Cool Down", 600000, 1, "Easy riding. Keep pedaling " +
        "and get breathing under control.  Towel off if needed.");

    // Workout
    var w1 = newWorkout("Treshold Test", "Threshold Test Description", "S1 Tip " +
        "1 S1 Tip 2 S1 Tip 3", warmUp2.concat([w1s1, w1s2, w1s3]));

    // ===================================================================== //


    // ====================== Tempo Intervals Workout ====================== //

    // Segments 
    var w2s1 = newSegment("HRZ 3", 600000, 3, getTipByType("Biking"));

    var w2s2 = newSegment("Easy Spin", 300000, 1, getTipByType("Biking"));

    var w2s3 = newSegment("Easy Spin", 600000, 1, getTipByType("Biking"));

    // Workout
    var w2 = newWorkout("Tempo Intervals", "Tempo Intervals Description",
        "w2 Tip 1\nw2 Tip 2\nw2 Tip 3", warmUp1.concat([w2s1, w2s2, w2s1, w2s2,
            w2s1, w2s3]));

    // ===================================================================== //

    // ======================= Sweet-Spot Intervals ======================== //

    // Segments 
    var w3s1 = newSegment("Sweet-Spot", 300000, 4, "Maintain a smooth pedal " +
        "stroke. Don't stromp on the pedals when you get tired. Pace your " +
        "effort evenly and avoid major fluctuations in heart rate.");

    var w3s2 = newSegment("Recovery", 60000, 1, "Maintain a smooth pedal " +
        "stroke. Reduce resistance and keep your legs turning over.");

    var w3s3 = newSegment("Sweet-Spot", 180000, 4, "Maintain a smooth pedal " +
        "stroke. Don't stromp on the pedals when you get tired. Pace your " +
        "effort evenly and avoid major fluctuations in heart rate.");

    var w3s4 = newSegment("Cool Down", 600000, 1, "Maintain a smooth pedal " +
        "stroke. Reduce resistance and keep your legs turning over.");

    // Workout
    var w3 = newWorkout("Sweet-Spot Intervals", "Use a medium " +
        "resistance/gear that allows you to maintain 90+ rpm during the " +
        "efforts. Efforts should be in Sweet-Spot HRZ high 3 - low 4 / PZ " +
        "88-93% FTP. Just spin easy against minimal resistance for the " +
        "recoveries.", "Pace the efforts evenly aiming to finish each " +
        "strongly. Start at the lower end of the zone and build through. " +
        "Maintain an even pedal stroke, don’t stamp on the pedals. " +
        "Hold your upper body still, don’t rock and keep your grip on your " +
        "bars relaxed.", warmUp2.concat([w3s1, w3s2, w3s1, w3s2, w3s3, w3s2,
            w3s3, w3s2, w3s3, w3s2, w3s3, w3s2, w3s3, w3s2, w3s4]));

    // ===================================================================== //

    // ========================== 3 x 10 minutes =========================== //

    // Segments 
    var w4s1 = newSegment("HRZ/PZ 3/4", 600000, 4, "Maintain a smooth pedal " +
        "stroke. Don't stromp on the pedals when you get tired. Pace your " +
        "effort evenly and avoid major fluctuations in heart rate.");

    var w4s2 = newSegment("Recovery", 600000, 1, "Maintain a smooth pedal " +
        "stroke. Reduce resistance and keep your legs turning over.");

    var w4s3 = newSegment("Cool Down", 600000, 1, "Maintain a smooth pedal " +
        "stroke. Reduce resistance and keep your legs turning over.");

    // Workout
    var w4 = newWorkout("3 x 10 minutes", "Cadence 90 rpm+ during the " +
        "efforts. Sweet-Spot is HRZ/PZ high 3 - low 4. Allow both to drop " +
        "to easy spinning during recovery.", "Pace the efforts as evenly as " +
        "possible, don’t go off too hard and maintain a consistent cadence. " +
        "Try to hold a stable racing position without excessive movement of " +
        "the upper body. Make sure you have a bottle of water to hand as " +
        "these are fairly long efforts. As you get stronger and more " +
        "confident with the session, try to ride predominately in HRZ/PZ 4.",
        warmUp2.concat([w4s1, w4s2, w4s1, w4s2, w4s1, w4s3]));

    // ===================================================================== //



    // ========================= Just 20-min WarmUp ======================== //

    var tstw1 = newWorkout("20-min WarmUp", "20-min WarmUp Description", "Tip " +
        "1 Tip 2 Tip 3", warmUp2);

    // ===================================================================== //

    // ================== 20-min WarmUp with preparation =================== //

    var tstw2 = newWorkout("40m Prep/Warm", "TO DO", "TO DO",
        warmUp2.concat(prep1));

    // ===================================================================== //

    // ============================ Unit Tests ============================= //

    var tstw3s1 = newSegment("Test1", 5000, 1, "Easy riding");
    var tstw3s2 = newSegment("Test2", 5000, 2, "Easy riding.");
    var tstw3s3 = newSegment("Test3", 5000, 3, "Easy riding.");
    var tstw3s4 = newSegment("Test4", 5000, 4, "Easy riding.");
    var tstw3s5 = newSegment("Test5", 5000, 5, "Easy riding.");
    var tstw3s6 = newSegment("Test6", 5000, 1, "Easy riding.");
    var tstw3 = newWorkout("Unit Tests", "Description", "tips",
        [tstw3s1, tstw3s2, tstw3s3, tstw3s4, tstw3s5, tstw3s6]);

    // ===================================================================== //



    // =============================== Morn ================================ //

    var tstw4s1 = newSegment("Laundry", 600000, 1, "Move clothes to/from laundry");
    var tstw4s2 = newSegment("Put things away", 600000, 1, "Throw away things " +
        "that aren't needed, put loose items away");
    var tstw4s3 = newSegment("Sweep", 600000, 2, "Sweep up all rooms");
    var tstw4s4 = newSegment("Dishes", 600000, 2, "Wash dishes, clean kitchen");
    var tstw4s5 = newSegment("Mop", 1200000, 3, "Mop all rooms");
    var tstw4s6 = newSegment("Vacuum", 600000, 2, "Vacuum as needed");
    var tstw4s7 = newSegment("Yoga", 1800000, 3, "Set up for and do yoga");
    var tstw4s8 = newSegment("Shower", 600000, 1, "Shower and hygeine");
    var tstw4 = newWorkout("2 Hr Morn Routine", "Description", "tips",
        [tstw4s1, tstw4s2, tstw4s3, tstw4s4, tstw4s1, tstw4s5, tstw4s6,
            tstw4s7, tstw4s8]);

    // ===================================================================== //

    // =============================== Afternoon ============================ //

    var tstw5s1 = newSegment("Laundry", 600000, 1, "Move clothes to/from laundry");
    var tstw5s2 = newSegment("Put things away", 600000, 1, "Throw away things " +
        "that aren't needed, put loose items away");
    var tstw5s3 = newSegment("Sweep/Vacuum", 600000, 2, "Sweep up all rooms");
    var tstw5s4 = newSegment("Dishes", 600000, 2, "Wash dishes, clean kitchen");
    var tstw5s5 = newSegment("Buy Stuff", 1200000, 1, "Buy crap on amazon");
    var tstw5s6 = newSegment("Make Lists", 600000, 1, "Buy crap on amazon");
    var tstw5s7 = newSegment("Meditation", 600000, 1, "Shower and hygeine");
    var tstw5 = newWorkout("1.5 Hr Afternoon", "Description", "tips",
        [tstw5s1, tstw5s2, tstw5s3, tstw5s4, tstw5s1, tstw5s5, tstw5s6,
            tstw5s7]);

    // ===================================================================== //

    // =============================== Evening ============================== //

    var tstw6s1 = newSegment("Foam roll", 600000, 1, "Roll it out");
    var tstw6s2 = newSegment("Food", 1200000, 1, "Eat and prpare food for tmw");
    var tstw6 = newWorkout("1.5 Hr Evening", "Description", "tips",
        [tstw6s2, tstw5s4, tstw5s2, tstw5s5, tstw6s1, tstw5s6, tstw4s8]);

    // ====================================================================== //

    // =============================== Morn2 ================================ //

    var tstw7s1 = newSegment("Start Breakfast", 300000, 1, "Oatmeal");
    var tstw7s2 = newSegment("Get Ready for Yoga", 600000, 1, "Get the area ready " +
        "put clothes on");
    var tstw7s3 = newSegment("Yoga", 2400000, 3, "Turn off the screens until done");
    var tstw7s4 = newSegment("Make List", 600000, 1, "Make list for work and lunch");
    var tstw7s5 = newSegment("Eat", 600000, 1, "Eat breakfast");
    var tstw7s6 = newSegment("Mo", 1200000, 2, "For moto");
    var tstw7s7 = newSegment("Shower", 600000, 1, "Shower and hygeine");
    var tstw7s8 = newSegment("Meditation", 900000, 1, "Turn off screens");
    var tstw7 = newWorkout("2 Hr Morn Routine", "Description", "tips",
        [tstw7s1, tstw7s2, tstw7s3, tstw7s4, tstw7s1, tstw7s5, tstw7s6,
            tstw7s7, tstw7s8]);

    // ====================================================================== //

    // =============================== Morn2 ================================ //

    var PRE0100 = newSegment("Set Up Tires", 600000, 1, getTipByType("Productivity"));
    var PRE0101 = newSegment("Clean Area", 300000, 1, getTipByType("Productivity"));
    var PRE0102 = newSegment("Set Displays", 300000, 1, getTipByType("Productivity"));
    var PRE0103 = newSegment("Gear Up", 300000, 1, getTipByType("Productivity"));
    var PRE0104 = newSegment("Pre/Post Drinks", 300000, 1, getTipByType("Productivity"));
    var PRE0105 = newSegment("Dynamic Stretching", 300000, 1, getTipByType("Productivity"));
    var PRE0201 = newSegment("Foam Roll - Calves", 120000, 1, getTipByType("FoamRoll"));
    var PRE0202 = newSegment("Foam Roll - Hamstrings", 120000, 1, getTipByType("FoamRoll"));
    var PRE0203 = newSegment("Foam Roll - Quads", 120000, 1, getTipByType("FoamRoll"));
    var PRE0204 = newSegment("Foam Roll - IT Band", 120000, 1, getTipByType("FoamRoll"));
    var PRE0205 = newSegment("Foam Roll - Abductor", 120000, 1, getTipByType("FoamRoll"));
    var PRE0206 = newSegment("Foam Roll - Glutes", 120000, 1, getTipByType("FoamRoll"));
    var PRE0207 = newSegment("Foam Roll - Back", 120000, 1, getTipByType("FoamRoll"));
    var PRE0208 = newSegment("Yoga", 1200000, 1, getTipByType("Productivity"));
    var BIKE0100 = newSegment("Z1 Active Recovery", 300000, 1, getTipByType("Biking"));
    var POST0101 = newSegment("Clean Up", 300000, 1, getTipByType("Productivity"));
    var POST0102 = newSegment("Dynamic Stretching", 300000, 1, getTipByType("Productivity"));

    var qw = newWorkout("Wednesday Workout", "Description", "tips",
        [PRE0100, PRE0101, PRE0102, PRE0103, PRE0104, PRE0105, PRE0105, PRE0201,
            PRE0202, PRE0203, PRE0204, PRE0205, PRE0206, PRE0207, PRE0208, BIKE0100,
            BIKE0100, BIKE0100, BIKE0100, BIKE0100, POST0101, POST0102]);

    // ====================================================================== //

    // =============================== Tues ================================ //

    var PRE1101 = newSegment("Threshold", 1 * 60 * 1000, 4, getTipByType("Biking"));
    var PRE1101b = newSegment("Recovery", 1 * 60 * 1000, 1, getTipByType("Biking"));
    var PRE1102 = newSegment("Threshold", 2 * 60 * 1000, 4, getTipByType("Biking"));
    var PRE1102b = newSegment("Recovery", 2 * 60 * 1000, 1, getTipByType("Biking"));
    var PRE1103 = newSegment("Threshold", 3 * 60 * 1000, 4, getTipByType("Biking"));
    var PRE1103b = newSegment("Recovery", 3 * 60 * 1000, 1, getTipByType("Biking"));
    var PRE1104 = newSegment("Threshold", 4 * 60 * 1000, 4, getTipByType("Biking"));
    var PRE1104b = newSegment("Recovery", 4 * 60 * 1000, 1, getTipByType("Biking"));
    var PRE1105 = newSegment("Threshold", 5 * 60 * 1000, 4, getTipByType("Biking"));
    var PRE1106 = newSegment("Cool Down", 10 * 60 * 1000, 1, getTipByType("Productivity"));


    var qw2 = newWorkout("Pyramid Intervals 1", "Description", "tips",
       [PRE1105, PRE1104b, PRE1104, PRE1103b, PRE1103,
           PRE1102b, PRE1102, PRE1101b, PRE1101, PRE1106]);

    // ====================================================================== //


    return qw2;

}