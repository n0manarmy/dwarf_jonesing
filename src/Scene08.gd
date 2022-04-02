extends Node2D

onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var job_manager = get_node("/root/JobManager")
onready var tm = get_node_or_null("/root/TextManager")
onready var main_menu_container = get_node("TextBackground/VBoxContainer/MainMenuContainer")
# onready var jobs_button_container = get_node("TextBackground/VBoxContainer/JobsMenuContainer/HBoxContainer/JobsButtonContainer/JobsContainer")
onready var jobs_container = get_node("TextBackground/VBoxContainer/JobsMenuContainer/JobsContainer")
onready var jobs_results_container = get_node("TextBackground/VBoxContainer/JobsMenuContainer/Text Box/JobsLabelBox")
onready var jobs_menu_container = get_node("TextBackground/VBoxContainer/JobsMenuContainer")
onready var global_data = get_node("/root/GlobalData")

const JobButton = preload("res://src/JobButton.gd")
const Job = preload("res://src/Job.gd")


var THIS_SCENE_EXIT = Vector2(27,43)

var jobs_button_container: VBoxContainer = VBoxContainer.new()
var debug_this = true
var jobs_presented = false

# signal_manager duplicating connection because _ready is being called twice. probably from travel path
func _ready():
	if debug_this: print(self.name + "._ready")
	main_menu_container.visible = true
	jobs_menu_container.visible = false
	signals_manager.connect("job_results_container_update", self, "update_job_results_container")
	
	
func on_done_clicked():
	if debug_this: print(self.name + ".on_done_clicked")
	if jobs_presented:
		jobs_button_container.queue_free()
		hide_menus()
		jobs_presented = false
	else:
		var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
		signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_world(THIS_SCENE_EXIT))
		signals_manager.emit_signal("on_done_clicked", self.name)
		self.hide()


func hide_menus():
	if debug_this: print(self.name + ".hide_menus")
	main_menu_container.visible = !main_menu_container.visible
	jobs_menu_container.visible = !jobs_menu_container.visible


func present_jobs(label):
	if debug_this: print(self.name + ".present_jobs")
	if debug_this: print(self.name + ".jobs size ", job_manager.jobs.size())
	if debug_this: print(self.name + ".jobs_button_container: ", jobs_button_container)

	if !is_instance_valid(jobs_button_container):
		jobs_button_container = VBoxContainer.new()
	
	jobs_results_container.text = tm.get_random_message(tm.JOBS_RESULTS_GREET)
	jobs_presented = true
	jobs_container.add_child(jobs_button_container)
	
	for job in job_manager.jobs:
		if job.scene == label:
			var button = Button.new()
			# var button = JobButton.new(job)
			# button.set_text_align(Button.ALIGN_LEFT)
			button.text = "{} - {} ${}".format([job.job_name, job.job_available, job.base_salary], "{}")
			button.connect("pressed", self, "this_job_pressed", [job])
			jobs_button_container.add_child(button)
			if debug_this: print(self.name + ".job ", job)


func on_company_button_pressed(scene: String):
	if debug_this: print(self.name, "scene: ", scene)
	hide_menus()
	present_jobs(scene)


func this_job_pressed(caller, job: Job):
	if debug_this: print(self.name, ".this_job_pressed()", " caller: ", caller)
	if debug_this: print(self.name, " ", job)
	var player = global_data.get_current_player()
	# signals_manager.emit_signal("increase_player_turn_time_used", 5)
	signals_manager.emit_signal("job_manager_check_get_job", self.name, job)
	player.turn_time_used += 5
	signals_manager.emit_signal("player_data_updated", self.name)
	# job_manager.can_get_job(player, job)

	
func update_job_results_container(results: String):
	if debug_this: print(self.name, ".update_job_results_container()")
	jobs_results_container.text = results
