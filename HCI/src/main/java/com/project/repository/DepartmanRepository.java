package com.project.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.project.domain.Departman;

public interface DepartmanRepository extends JpaRepository<Departman, Long>{
	Departman save(Departman u);
	void delete(Departman u);
	Departman findByLabel(Departman u);
}
