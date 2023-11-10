extends Object

@export var pos: int
@export var scene: String
@export var company: String
@export var job_name: String
@export var base_salary: int
@export var required_degree: String
@export var required_work_exp: int
@export var job_available: bool

var debug_this = true

func _init(_pos, _scene, _company, _job_name, _base_salary, _required_degree, _required_work_exp, _job_available):
	self.pos = _pos
	self.scene = _scene
	self.company = _company
	self.job_name = _job_name
	self.base_salary = _base_salary
	self.required_degree = _required_degree
	self.required_work_exp = _required_work_exp
	self.job_available = _job_available


func _ready():
	if debug_this: print(self.name, "._ready")
	pass

func _to_string():
	return "Job -- \"Pos:\" {} \"Scene:\" {} \"Company:\" {} \"Job Name:\" {} \"Base Salary:\" {} \"Required Degrees:\" {} \"Required Work Exp:\" {} \"Job Available:\" {}".format([self.pos, self.scene,	self.company,	self.job_name,	self.base_salary,	self.required_degree,	self.required_work_exp,	self.job_available], "{}")
