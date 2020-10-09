from string_builder import StringBuilder
from infix_to_postfix import Conversion

infix_file_name = 'all_infix_perms.txt'

# sb = StringBuilder()
# sb.string_builder_helper('', 0, 0, 0)



with open(infix_file_name) as infix_exprs:
  for infix_expr in infix_exprs:
    infix_expr = infix_expr.strip()
    obj = Conversion(len(infix_expr)) 
    postfix = obj.infixToPostfix(infix_expr) 
    print(postfix)