'''
CODE ADAPTED FROM:
G4G string building: https://www.geeksforgeeks.org/print-all-possible-combinations-of-r-elements-in-a-given-array-of-size-n/
G4G in to post and eval: https://www.geeksforgeeks.org/stack-set-2-infix-to-postfix/
G4G postfix eval https://www.geeksforgeeks.org/stack-set-4-evaluation-postfix-expression/

fix and recur method

'''

  '''
  TODO:
  remove duplicate cards??
  at least one operand in the parenthesis (but can have more)
  '''

MAX_OPERANDS = 4
MAX_OPEN = MAX_CLOSE = 2
operands = ['6', '7', '2', '1']
parenthesis = ['(', ')']
operators = ['+', '-', '*', '/']

class StringBuilder:

  def __init__(self):


    # delete and recreate output file
    with open('all_infix_perms.txt', 'w') as output:
      pass



  def string_builder_helper(
    self,
    infix_string, 
    operands_used,
    open_used,
    closed_used
    ):
    
    # base case: we have reached the end of string if MAX_OPERANDS is hit
    if(operands_used == MAX_OPERANDS):    
      # close all remaining parenthesis
      infix_string += ')'*(open_used - closed_used)
      # print(infix_string)
      with open('all_infix_perms.txt', 'a') as output:
        output.write(infix_string+'\n')
      return
    
    # if string is empty then first character can be 
    elif (len(infix_string) == 0):

      # open parenthesis
      self.string_builder_helper(infix_string+'(', 0, 1, closed_used)

      # or an operand 
      for operand in operands:
        self.string_builder_helper(infix_string+operand, 1, open_used, closed_used)
    
    # else some other point in the string
    else:
      
      # if last character is operand or closed parenthesis
      if(infix_string[-1] in operands + [')']):

        # then the next character can be closed too, only if open > closed
        # AND there is at least one operator in between
        if(open_used > closed_used):
          self.string_builder_helper(infix_string+')', operands_used, open_used, closed_used+1)

        # or the next can be an operator
        for character in operators:
          self.string_builder_helper(infix_string+character, operands_used, open_used, closed_used)
      
      # or last character is operator or open parenthesis
      elif (infix_string[-1] in operators + ['(']):

        # then the next character can be open too, only if the MAX_OPEN count is not reached
        if(open_used < MAX_OPEN):
          self.string_builder_helper(infix_string+'(', operands_used, open_used+1, closed_used)

        # or the next can be an operand      
        for character in operands:
          self.string_builder_helper(infix_string+character, operands_used+1, open_used, closed_used)


