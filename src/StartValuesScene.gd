extends Node2D

var vbox_container_name =           "VBoxContainer/"
var hbox_goals_container_name =      "HBoxGoalsLabelContainer/"
var hbox_slider_container_name =     "HBoxSliderContainer/"
var goals_value = vbox_container_name + "HBoxGoalsLabelContainer/GoalsValue"
var wealth_slider = vbox_container_name + hbox_slider_container_name + "HBoxWealthContainer/WealthSlider"
var happiness_slider = vbox_container_name + hbox_slider_container_name + "HBoxHappinessContainer/HappinessSlider"
var education_slider = vbox_container_name + hbox_slider_container_name + "HBoxEducationContainer/EducationSlider"
var job_slider = vbox_container_name + hbox_slider_container_name + "HBoxJobContainer/JobSlider"

var STARTING_SLIDER_VALUE = 50
var DEFAULT_GOALS_LABEL_VALUE = "Player %s Goals"

onready var goals_label = get_node(vbox_container_name + "HBoxGoalsLabelContainer/GoalsLabel")
onready var wealth_slider_node = get_node(wealth_slider)
onready var job_slider_node = get_node(job_slider)
onready var education_slider_node = get_node(education_slider)
onready var happiness_slider_node = get_node(happiness_slider)
onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var global_data = get_node("/root/GlobalData")

var debug_this = true

# Called when the node enters the scene tree for the first time.
func _ready():
	if debug_this: print(self.name + "._ready()")
	#self.goals_values_updated.connect("update_goals_value")
	signals_manager.connect("goals_values_updated", self, "update_goals_value")
	if debug_this: print(self.name + ".global_variables.current_player ", global_data.current_player)
	goals_label.text = DEFAULT_GOALS_LABEL_VALUE % (global_data.current_player as String)

func slider_value_changed(x):
	if debug_this: print(self.name + ".slider_value_changed()", x)
	signals_manager.emit_signal("goals_values_updated")

func on_done_clicked():
	#add logic to look for current player and cycle, taking max score until players met
	if debug_this: print(self.name + ".on_done_clicked()")
	
	var values = {
		"max_wealth": wealth_slider_node.value, 
		"max_job": job_slider_node.value,
		"max_education": education_slider_node.value,
		"max_happiness": happiness_slider_node.value
		}
	
	signals_manager.emit_signal("goals_values_done", values)
	
	if global_data.current_player == global_data.player_count:
		if debug_this: print(self.name + ".if global_variables.current_player == global_variables.player_count:")
		signals_manager.emit_signal("remove_board_overlay")
		signals_manager.emit_signal("increment_player")
		signals_manager.emit_signal("update_debug_scene")
		signals_manager.emit_signal("reset_players")
		signals_manager.emit_signal("disable_location_buttons", false)
		queue_free()
	else:
		if debug_this: print(self.name + ".else")
		signals_manager.emit_signal("increment_player")
		signals_manager.emit_signal("update_debug_scene")
		goals_label.text = DEFAULT_GOALS_LABEL_VALUE % global_data.current_player		
		reset_sliders()
	
func update_goals_value():
	if debug_this: print(self.name + ".update_goals_value")	
	
	get_node(goals_value).text = (
		wealth_slider_node.value +
		job_slider_node.value + 
		education_slider_node.value +
		happiness_slider_node.value) as String
	
func update_max_score(val):
	if debug_this: print(self.name + ".update_max_score")
	
	goals_value.text = val as String

func reset_sliders():
	wealth_slider_node.value = STARTING_SLIDER_VALUE
	job_slider_node.value = STARTING_SLIDER_VALUE
	education_slider_node.value = STARTING_SLIDER_VALUE
	happiness_slider_node.value = STARTING_SLIDER_VALUE
