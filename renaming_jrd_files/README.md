# Renaming JRD90 Workout files

The JRD90 pdf takes very long to load, even when stored locally on my phone.

Each workout is on a separate page within the pdf. Workouts are labelled by week and day.

My initial plan involved using [this](https://pdf2jpg.net/) site to convert the pdf to individual `.jpgs` and upload them to either Google Photos or Drive. However this approach made searching for a particular workout tedious since the website renamed the workouts in sequence (0 - 64) whereas I would much rather prefer having the files named with the syntax `week_x_day_y`.

I wrote this simple python script (with hardcoded values, so it's not that great) to copy files with the old filename, to a new directory with the new filenames.

The goal is to get more comfortable in quickly prototying simple scripts that would automate similar mundane tasks in my workflow.

## Roadmap
- Use list/dict comprehension to generate new filenames.
- Rewrite in bash, just for experience.
- Generalise to accept old and new dirs as command line args.
- Currently the new dir must exist before new files are written to it. The script should be able to make new dirs autonomously.
- Experiment with regex to generate any syntax I want.
