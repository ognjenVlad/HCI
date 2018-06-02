package com.project.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.project.domain.Ucionica;

public interface ClassroomRepository extends JpaRepository<Ucionica, Long> {
	Ucionica save(Ucionica u);
	void delete(Ucionica u);
	Ucionica findByLabel(Ucionica u);
}
