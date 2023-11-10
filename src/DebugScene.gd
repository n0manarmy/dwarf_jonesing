extends Node2D

@onready var total_time_value_node = 			get_node("DebugContainer/HBoxContainer/VBoxValues/TotalTimeValue")
@onready var turn_time_used_value_node = 		get_node("DebugContainer/HBoxContainer/VBoxValues/TimeUsedValue")
@onready var status_value_node = 				get_node("DebugContainer/HBoxContainer/VBoxValues/StatusValue")
@onready var eaten_value_node = 					get_node("DebugContainer/HBoxContainer/VBoxValues/EatenValue")
@onready var rounds_value_node = 				get_node("DebugContainer/HBoxContainer/VBoxValues/RoundsValue")
@onready var job_value_node = 					get_node("DebugContainer/HBoxContainer/VBoxValues/JobNameValue")
@onready var money_value_node = 					get_node("DebugContainer/HBoxContainer/VBoxValues/MoneyValue")

@onready var happiness_score_value_node = 		get_node("DebugContainer/HBoxContainer2/VBoxValues/HappinessScoreValue")
@onready var wealth_score_value_node = 			get_node("DebugContainer/HBoxContainer2/VBoxValues/WealthScoreValue")
@onready var job_score_value_node = 				get_node("DebugContainer/HBoxContainer2/VBoxValues/JobScoreValue")
@onready var education_score_value_node = 		get_node("DebugContainer/HBoxContainer2/VBoxValues/EducationScoreValue")

@onready var max_happiness_score_value_node = 	get_node("DebugContainer/HBoxContainer3/VBoxValues/MaxHappinessScoreValue")
@onready var max_wealth_score_value_node = 		get_node("DebugContainer/HBoxContainer3/VBoxValues/MaxWealthScoreValue")
@onready var max_job_score_value_node = 			get_node("DebugContainer/HBoxContainer3/VBoxValues/MaxJobScoreValue")
@onready var max_education_score_value_node = 	get_node("DebugContainer/HBoxContainer3/VBoxValues/MaxEducationScoreValue")

@onready var current_player_value_node = 		get_node("DebugContainer/HBoxContainer2/VBoxValues/CurrentPlayerValue")
@onready var total_players_value_node = 			get_node("DebugContainer/HBoxContainer2/VBoxValues/TotalPlayersValue")
@onready var work_experience_value_node = 		get_node("DebugContainer/HBoxContainer2/VBoxValues/WorkExpValue")

@onready var signals_manager = 					get_node_or_null("/root/SignalsManager")
@onready var global_data = 						get_node_or_null("/root/GlobalData")
@onready var timer_engine = 						get_node_or_null("/root/TimerEngine")
@onready var scoring_engine = 					get_node_or_null("/root/ScoringEngine")
@onready var player_count_select_scene =			get_node_or_null("/root/RootScene/PlayerCountSelectScene")
@onready var start_values_scene =				get_node_or_null("/root/RootScene/StartValuesScene")
@onready var location_entry_area_2d = 			find_child("TravelPath", true, false)

var debug_this = false

# Called when the node enters the scene tree for the first time.
func _ready():
	self.position.y = 770
	self.position.x = 5
	if debug_this: print(self.name + "._ready")
	timer_engine.connect("update_round_timer", Callable(self, "update_time_used_label"))
	scoring_engine.connect("update_value", Callable(self, "update_value_label"))
	
	signals_manager.connect("global_data_updated", Callable(self, "update_global_data"))
	signals_manager.connect("player_data_updated", Callable(self, "update_player_data"))


func update_global_data(caller):
	if debug_this: print(self.name + ".update_global_data", " caller: ", caller)
	rounds_value_node = global_data.game_rounds

func update_player_data(caller):
	if debug_this: print(self.name + ".update_player_data", " caller: ", caller)
	
	var player = global_data.get_current_player()
	
	current_player_value_node.text = str(global_data.current_player)
	total_time_value_node.text = str(global_data.MAX_TIME)
	turn_time_used_value_node.text = str(player.turn_time_used)
	#status_value_node.text = current_player
	eaten_value_node.text = str(player.eaten)
	rounds_value_node.text = str(global_data.game_rounds)
	job_value_node.text = str(player.current_job.job_name)
	money_value_node.text = str(player.current_money)
	
	happiness_score_value_node.text = str(player.happiness_score)
	wealth_score_value_node.text = str(player.wealth_score)
	job_score_value_node.text = str(player.job_score)
	education_score_value_node.text = str(player.education_score)
	
	max_happiness_score_value_node.text = str(player.max_happiness_score)
	max_wealth_score_value_node.text = str(player.max_wealth_score)
	max_job_score_value_node.text = str(player.max_job_score)
	max_education_score_value_node.text = str(player.max_education_score)
	
	work_experience_value_node.text = str(player.work_exp)
	
	current_player_value_node.text = str(global_data.current_player)
	total_players_value_node.text = str(global_data.players.size())
	
func update_time_used_label(val):
	status_value_node.text = str(val)
