extends Node

onready var tm = get_node("/root/TextManager")

export var scene_03_jobs: Dictionary = {
	"Company": tm.SCENE03_JOBS_COMPANY, "jobs": 
	[
		{"Name": tm.SCENE03_JOBS_1},
		{"base_salary": 5},
		{"required_degress": ""},
		{"required_work_experience": ""},
		{"available": true}
	],
	[
		{"Name": tm.SCENE03_JOBS_1},
		{"base_salary": 5},
		{"required_degress": ""},
		{"required_work_experience": ""},
		{"available": true}
	],
	[
		{"Name": tm.SCENE03_JOBS_1},
		{"base_salary": 5},
		{"required_degress": ""},
		{"required_work_experience": ""},
		{"available": true}
	]
}




# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.
