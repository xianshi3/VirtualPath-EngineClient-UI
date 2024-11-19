#pragma once

#include "Mesh.h"

namespace VirtualPathCore
{
	class MeshFactory
	{
	public:
		static Mesh* CreateTriangle(float size = 0.5f);

		static Mesh* CreateCube(float size = 0.5f);
	};
}