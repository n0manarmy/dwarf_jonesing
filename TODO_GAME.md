# Current
* [DONE] Movement of player sprite starts from position where last click occured, not last position of sprite.
* [DONE] Give thought to best way to resetting player position when done clicked
* [DONE] wire in travelpath, infoscene, signals
* limit happiness gain based on total items for possible happiness
* Finish up Rental Office.
  * [DONE] Make checks on worth o make sure they can rent low cost or le security before allowing rental
* add time loss to each job application
* increase time loss from lack of food (make relative to total game time)
* [DONE] When running out of time on the track, player stops and does not reset

# Tasks
* [DONE]Add time increment when visiting location
* [DONE] prompt display at visit
  * [DONE] Prevent movement until done clicked
* [DONE] Build framework for presenting info screen
  * [DONE] Start with the employment building.
    * [DONE] List all work places, base salary
    * [DONE] build base qualifications for jobs
* Build a clock to show time
* [DONE] Tie DebugScene to player status in gamedata
* Location
  * [HOLD] Build the employment office menu. 
      * [DONE] Capture CollisionShape2D enter squares
      * [DONE] Pop menu!
      * [DONE] Added call backs for gui menus. Work on call backs and setting player values
      * [DONE] Add # of players screen.
      * [DONE] Logic for setting score for current player. At start of each character turn, update debug screen score with current player scores.
      * [DONE] Work on getting zlevel fixed for presenting job scene
    * [DONE] Add degrees required for crafts job.
    * [DONE] show crafts job menu
# Bugs
* [DONE] Loading does not hide respective menus