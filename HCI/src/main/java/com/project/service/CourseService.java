package com.project.service;

import com.project.domain.Course;

public interface CourseService {

	Course save(Course u);
	boolean delete(Course u);
	Course change(Course u);
}
