extends Node2D

onready var total_time_value_node = 			get_node("DebugContainer/HBoxContainer/VBoxValues/TotalTimeValue")
onready var turn_time_used_value_node = 		get_node("DebugContainer/HBoxContainer/VBoxValues/TimeUsedValue")
onready var status_value_node = 				get_node("DebugContainer/HBoxContainer/VBoxValues/StatusValue")
onready var eaten_value_node = 					get_node("DebugContainer/HBoxContainer/VBoxValues/EatenValue")
onready var rounds_value_node = 				get_node("DebugContainer/HBoxContainer/VBoxValues/RoundsValue")
onready var job_value_node = 					get_node("DebugContainer/HBoxContainer/VBoxValues/JobNameValue")

onready var happiness_score_value_node = 		get_node("DebugContainer/HBoxContainer2/VBoxValues/HappinessScoreValue")
onready var wealth_score_value_node = 			get_node("DebugContainer/HBoxContainer2/VBoxValues/WealthScoreValue")
onready var job_score_value_node = 				get_node("DebugContainer/HBoxContainer2/VBoxValues/JobScoreValue")
onready var education_score_value_node = 		get_node("DebugContainer/HBoxContainer2/VBoxValues/EducationScoreValue")

onready var max_happiness_score_value_node = 	get_node("DebugContainer/HBoxContainer3/VBoxValues/MaxHappinessScoreValue")
onready var max_wealth_score_value_node = 		get_node("DebugContainer/HBoxContainer3/VBoxValues/MaxWealthScoreValue")
onready var max_job_score_value_node = 			get_node("DebugContainer/HBoxContainer3/VBoxValues/MaxJobScoreValue")
onready var max_education_score_value_node = 	get_node("DebugContainer/HBoxContainer3/VBoxValues/MaxEducationScoreValue")

onready var current_player_value_node = 		get_node("DebugContainer/HBoxContainer2/VBoxValues/CurrentPlayerValue")
onready var total_players_value_node = 			get_node("DebugContainer/HBoxContainer2/VBoxValues/TotalPlayersValue")

onready var global_data = 						get_node_or_null("/root/GlobalData")
onready var timer_engine = 						get_node_or_null("/root/TimerEngine")
onready var scoring_engine = 					get_node_or_null("/root/ScoringEngine")
onready var player_count_select_scene =			get_node_or_null("/root/RootScene/PlayerCountSelectScene")
onready var start_values_scene =				get_node_or_null("/root/RootScene/StartValuesScene")

var debug_this = true

# Called when the node enters the scene tree for the first time.
func _ready():
	self.position.y = 770
	self.position.x = 5
	if debug_this: print(self.name + "._ready")
	timer_engine.connect("update_round_timer", self, "update_time_used_label")
	scoring_engine.connect("update_value", self, "update_value_label")
	
	if start_values_scene != null:
		start_values_scene.connect("update_debug_scene", self, "update_player_data")
	if player_count_select_scene != null:
		player_count_select_scene.connect("update_debug_scene" , self, "update_player_data")
	if global_data != null:
		update_player_data()
		global_data.connect("player_data_updated", self, "update_player_data")
		
	if get_node_or_null("/root/RootScene/TravelPath") != null:
		var location_entry_area_2d = get_node_or_null("/root/RootScene/TravelPath")
		location_entry_area_2d.connect("update_player_data", self, "update_player_data")
	elif get_node_or_null("/root/TravelPath") != null:
		var location_entry_area_2d = get_node_or_null("/root/TravelPath")
		location_entry_area_2d.connect("update_player_data", self, "update_player_data")
	
func update_player_data():
	if debug_this: print(self.name + ".update_player_data ", global_data.current_player as int, " size: ", global_data.players.size())
	
	var current_player = global_data.players[global_data.current_player - 1]
	if debug_this: print(self.name + ".current_player: ", current_player)
	
	current_player_value_node.text = global_data.current_player as String
	total_time_value_node.text = global_data.MAX_TIME as String
	turn_time_used_value_node.text = current_player.turn_time_used as String
	#status_value_node.text = current_player
	eaten_value_node.text = current_player.eaten as String
	rounds_value_node.text = global_data.game_rounds as String
	job_value_node.text = current_player.current_job as String
	
	happiness_score_value_node.text = current_player.happiness as String
	wealth_score_value_node.text = current_player.wealth as String
	job_score_value_node.text = current_player.job as String
	education_score_value_node.text = current_player.education as String
	
	max_happiness_score_value_node.text = current_player.max_happiness as String
	max_wealth_score_value_node.text = current_player.max_wealth as String
	max_job_score_value_node.text = current_player.max_job as String
	max_education_score_value_node.text = current_player.max_education as String
	
	current_player_value_node.text = global_data.current_player as String
	
func update_time_used_label(val):
	status_value_node.text = val as String
