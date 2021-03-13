import random
import time
import sys 

support = ['Looking Good!','*Snaps* Yes!','My Man!', 'TWITCH', 'PRIME', 'TWITCH PRIME']
tehe = '*Laughs in 1s and 0s*'
def Random_Support():
    return print('DavaSupport: ' + random.choice(support))

def Method1():
	print('DavaSupport: Sup, ' + UI1 + ' my name is DavaSupport')

def Method2():
	print('DavaSupport: huh that is an interesting problem ' + UI1 + ' have you tried pressing enter again?')
	
def Method3():
	print('DavaSupport: that should do it, cya ' + UI1)
	
def Method4():
	print('DavaSupport: Later ' + UI1 + ' also you will have you run this whole gamut again '+ tehe)

UI1 = input("DavaSupport: What is your name : ")

Method1()

time.sleep(2)

UI2 = input("DavaSupport: What Can I Help you with? ")

Method2()

input()

Random_Support()

time.sleep(2)

Method3()

time.sleep(4)

UI3 = int(input('DavaSupport: Still here ' + UI1 + ', so you actually having issues or looking to see how far the rabbit hole goes?' 
            + ' Please press 1 and then the enter for actual help. ' + 'Please press 2 and then the enter key to see how far this goes on.'))
x = UI3

if x > 2:
    print('DavaSupport: Nice try smart ass...')

elif x < 1:
    print('DavaSupport: Nice try smart ass...')

elif x == 1:
    print('DavaSupport: Please make sure that the paths in the launcher are to the folder that has the executable')

elif x ==2:
    print('DavaSupport: This actually is it')

time.sleep(5)

Method4()

input("Press any key to close the program")
