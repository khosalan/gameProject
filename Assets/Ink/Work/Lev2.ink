->start
===start
#background:christmas
Its Christmas season and work are getting busy because the business year is about to end.  You’ve been working well so far and you’ve maintained a good relationship with your coworkers. 
Your company is planning on having a Christmas party as a way of keeping everyone happy and relaxed.
#background:talkcowo
You hear that they are looking for people for the party planning committee. Your friend said that she is going to join and asks if you’d like to join too. 
*[Join the committee]
->partyPlanning
*[Politely refuse the invitation]
#remark:A balance person needs extra work as well as work

->END
===partyPlanning
#background:meeting
You went with your friend to the meeting which was held after work. During the meeting the committee discussed the date and venue was discussed. 
They also mentioned the members would have to stay a little bit late after work once or twice a week for organizing work.
#background:thinkalone
Then the meeting ended and on the way home you think about whether or not to stay in the committee. And you have to decide
*[Stay in the committee]
->planningContinues
*[Leave because you’ll have to stay late]
#remark:staying in the committee would've been a good expirience for you.

->END
===planningContinues
#background:meeting2
In the next meeting the committee discussed about the venue and theme of the party. After coming to a final decision, the meeting adjourned. You were told to give out any details about the party.
#background:talkcowo
A few days later a coworker approached you during the lunch time he started asking about the Christmas party. He asked about the theme of the party.
*[Tell him the theme and the venue]
#remark:You shouldn't have told him because it was something that was trusted upon you by the team
*[Tell him that it’s a secret and you’ll find out on the day like the rest of the office]
-
#background:thinkalone
Couple of days later you were asked to stay late for some matter regarding the party. 
After work the committee head came to you and asked if you would be able to come on a Saturday to check if the venue is available. You have to decide 
*[Tell him you are free]
*[Tell him a lie about not being free]
#remark:you should have gone with him because you took a responsibility when you joined the committee
-->supplies



===supplies
#background:committee
One morning you were told to find a place to purchase some party supplies by the head of the party planning committee. You were able to contact a school friend to find a party supply shop.
#background:thinkalone
A few hours later you started to think if you would be able to use the party supplies as a cover up and go home early. So, you started thinking
*[Stay and work]
*[Lie and go home early]
#remark:You shouldn't lie to get out of work
-
#background:meeting
During the next meeting you told the heads about the party supply shop. Then they asked you if you would be able to handle the payments.
#background:meeting2
They asked you to bring the bills so that you will be able to compensate you for the things.
#background:bill
The next day you call your friend to discuss the prices. After work you go to his shop to get a bill.
#background:aboutbill
You started to think about getting a bill with a higher amount so that you can keep some money for yourself.  Now you have to decide.
*[Do it]
#remark:lying to your workplace is a very bad habit
*[Don’t do it]
-
->final
->END
===final
#background:commitee
Work and party planning continue as usual. The committee decide to plan a secret Santa to cheer everyone up. 
#background:eating
During the lunch break names were given to everyone who they’re supposed to get gifts for. You got a name for a coworker who you are friends with.
#background:thinkalone
After the discussion, you started thinking about what you should buy as a gift. 
You have to decide
*[Buy him something cheap]
#remark:You should not be cheap when geting someone a gift
*[Buy him something good]
-
#background:partywell
The day of the party came and you went to the venue early so that you and the others can finish the final bits of the party.  You finish everything in time and others started coming in. 
The party went really well. Every one got the gifts and enjoyed themselves really well. Everyone thanked the party planning committee for a job well done.
#background:coworkertalkingparty
After the party some of your coworkers said they are going to one of their houses to hang out a little bit more. They asked if you would join.
Now you have to decide
*[Go home]
#background:happy
You  go home and rest. You are happy about what you and the other committee memebrs did.
*[Go with them]
#background:fun
You go to your friends house. You guys had fun  joking around. You had a lot of fun.
-
->END