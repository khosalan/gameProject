->start
=== start
#background:startlevel
Now you are a second-year student. The workload has increased but you still have some time to spend with your friends and enjoy. 
#background:goodresults
Your grades so far have been good. And you have a good reputation among your friends.You notice that some of your friends have lower grade.

#background:planning
One day your friends decide to go out after lectures and have some fun. They also decide to get together and have a study session after that at a friend’s house. They asked if you would like to join.Now you have to decide,
*[Go out and have fun]
    #background:fun
    You go out with your friends and have a good. Then they start to talk about the study session. They ask you if you have to time to join and teach them some topics that are hard for them. You have to decide,
        **[Help the with the studies]
        #background:teaching
            After decision, you go to your friend’s house and teach then the topics they want. You realize that helping them also made some topics easier for you.
            ->timeGoes
        **[Go home and study alone]
        #remark:You should have helped them. It is good habit to share your knowledge with others and it will also help you gain knowledge....
        #background:remarkthink
        << You should have helped them. It is good habit to share your knowledge with others and it will also help you to gain knowledge....>>
            ->timeGoes
            
*[Tell them that you have some family matter (go home and study alone)]
#remark:Studying isn't everything, you should have some fun time with friends. You'll learn more things through the experiance of the life
#background:remarkthink
<< Studying isn't everything, you should have some fun time with friends. You'll learn more things through the experiance of the life >>
->timeGoes
    

=== timeGoes
#background:studyalone
Time goes on and work so far has been going well.Assignments are starting to come up some students are struggling to keep up with the work. You are able to keep up with everything.
#background:onetalkone
Few days before an assignment a friend of yours asked for your help to resolve some confusing parts of subjects. Again, you have to decide,
*[Help your friend]
    #background:teaching
    You help your friend and both of you do well in the assignment.
*[Tell him that you don't know that part]
#remark:You should not lie to your friends. Your friends are starting to notice that you are ditching and the friendship is starting to deteriorate
#background:remarkthink
<< You should not lie to your friends. Your friends are starting to notice that you are ditching and the friendship is starting to deteriorate >>
    
-#background:university
University life continues as usual you and your friends have fun.

#background:discussion 
A few days later lectures end early some of your friends along with some batch mates decided to go watch a movie in the theatr. They ask you to join. And you start thinking whether its better to,
 
*[Go out with your friends and have fun]
    ->goingOut
*[Go to the library and study]
#background:remarkthink
You should not focus on studying all the time. A balanced human needs friends not just only education. Think about it !!!
->END
===goingOut
#background:theatre
You watch the movie and have a lot of fun. Someone suggests that they should go to some restaurant and grab something to eat. 
#background:sad
You notice that one of your friends looks upset.Now you have to decide that you have to either,
*[Ask him what’s wrong]
    #background:onetalkone
    If you decide to ask your friend what’s wrong you find out that your friend is a little bit low on cash. And that he’s thinking about going home without going to the restaurant.
    #background:lendingmoney
    You have enough money to lend him some money so that he can hang out with friends.
    
        **[Lend him some money so that he can stay]
        #background:onetalkone
            He thanks you and joins the group
        **[Don’t lend him the money so that you can save up]
        #background:sad
        Your friends say he’s getting late and has to go home.
        #remark:You should help your friends when they are in hard situation
        #background:remarkthink
        << You should help your friends when they are in hard situation >>
    
        --
        #background:fun
        You have fun with your friends. You go home satisfied.
*[Mind your own business]
#remark:You should care about your friends a litte bit more. Not caring about your friends when they are in hard situation is a bad habit. Think about it !!!
#background:remarkthink
<< You should care about your friends a litte bit more. Not caring about your friends when they are in hard situation is a bad habit. Think about it !!! >>

-->academicsContinue

===academicsContinue
#background:university
University goes on normally everything fine you are doing well in academics.

#background:lecturersay
A few days later a during a lecture the lecturer says that there will be a assignment on what you’ve learned so far. You are pretty confident with what you’ve learned so far.
#background:discussion
The assignment is getting closer and on the day before the assignment your best friends asks if you could help him with some part that he has problem with some topics. Even though you are confident with the subject you feel like you have to go through the topics just in case.
Now you have to decide between
 
*[Help your friend with the topic]
*[Make some lie up and go home to study by yourself]
#remark:You should help your friend with their studies. It wil help them to pass the assignment as well as you gain more knowledge when teaching someone. Think about it
#background:remarkthink
<< You should help your friend with their studies. It wil help them to pass the assignment as well as you gain more knowledge when teaching someone. Think about it ...>>
#background:sad
He messes up the assignment get stressed out.
-
#background:happy
you do well in the assignment.
->cricketMatch

===cricketMatch
#background:talk4
University continues as usual. And exams are getting extremely close. 
#background:cricket
The student union has decided to hold a cricket tournament to reduce exam stress at the beginning of the study leave.
#background:discussion
Your friends have decided to enter a team into the tournament. Your friends asks you to join the game. Now you have to decide if its better to
 
*[Join them and play in the tournament]
    #background:cricket
    You play in the tournament and have fun.
*[Not play in the tournament study for the exam]
#background:remarkthink
<< Playing in the tournament would have been a fun time it would help you reduce stress >>
-
->finale
===finale
#background:planning
A few days before the exam your friends ask you if you could come to the university on the days that you don’t have university so that you can help them with difficult parts of the subjects and study with them. Now you have to decide to
 
*[Go help them]
#remark:Helping your freinds with their studies is a good habit and which will help them to pass their examination. Keep it up
#background:remarkok
Helping your freinds with their studies is a good habit and which will help them to pass their examination. Keep it up
*[Study alone]
#remark:Helping your friends in their studies would help your freinds to pass their examination and also result in you understanding the subjetcs a little bit better. Think about it and change your mindset.
#background:remarkthink
<<Helping your friends in their studies would help your freinds to pass their examination and also result in you understanding the subjetcs a little bit better. Think about it and change your mindset.>>
-->END
