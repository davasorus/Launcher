import random
from random import choice
import time
import sys

support = ['Looking Good!','*Snaps* Yes!','My Man!', 'Something Here 1', 'Something Here 2', 'Something Here 3']
tehe = '*Laughs in 1s and 0s*'
def method_name():
    print('DavaSupport: ' + random.choice(support))

UI1 = input("DavaSupport: What is your name: ")

print('DavaSupport: Sup, ' + UI1 + ' my name is DavaSupport /n')

time.sleep(2)

UI2 = input("DavaSupport: What Can I Help you with? ")

print('DavaSupport: huh that is an intersting problem ' + UI1 + ' have you tried pressing enter again?')
input()

method_name()

time.sleep(2)

print('DavaSupport: that should do it, cya ' + UI1)

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

print('DavaSupport: Later ' + UI1 + ' also you will have you run this whole gamut again '+ tehe)
