# JRD90_DIR = "~/Downloads/jrd90"
from shutil import copyfile

JRD90_OLD_DIR = "/home/chris/Downloads/jrd90"
JRD90_NEW_DIR = "/home/chris/Downloads/jrd90_renamed"
OFFSET_WEEK_1_DAY_1 = 5  # WEEK 1 DAY 1 OFFSET
NUM_WEEKS = 12
DAYS_PER_WEEK = 5

def get_old_filename(old_filenumber):
  return f"12 WEEK WORKOUT PLAN - 5-page-{old_filenumber:03}.jpg"

old_filenumber = OFFSET_WEEK_1_DAY_1
for week in range(1, NUM_WEEKS+1):
  for day in range(1, DAYS_PER_WEEK+1):
    old_filename = get_old_filename(old_filenumber)
    new_filename = f"jrd90_week_{week}_day_{day}.jpg"
    # print(f"{old_filename} -> {new_filename}")
    copyfile(f"{JRD90_OLD_DIR}/{old_filename}", f"{JRD90_NEW_DIR}/{new_filename}")
    old_filenumber+=1
