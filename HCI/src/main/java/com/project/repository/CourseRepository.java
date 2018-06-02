package com.project.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.project.domain.Course;

public interface CourseRepository extends JpaRepository<Course, Long>{
	Course save(Course u);
	void delete(Course u);
	Course findByLabel(Course u);
}
