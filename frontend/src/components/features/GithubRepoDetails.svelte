<script lang="ts">
	const languages = [
		{ name: 'TypeScript', percentage: 37.9, color: '#3178C6' },
		{ name: 'C#', percentage: 18.8, color: '#178601' },
		{ name: 'CSS', percentage: 15.9, color: '#563d7c' },
		{ name: 'Svelte', percentage: 15.4, color: '#FF3E00' },
		{ name: 'JavaScript', percentage: 5.5, color: '#f1e05a' },
		{ name: 'Dockerfile', percentage: 4.4, color: '#384d54' },
		{ name: 'Other', percentage: 2.1, color: '#ededed' }
	];
</script>

<div>
	<div class=" flex h-2 w-full overflow-hidden rounded-full">
		{#each languages as lang}
			<div
				class="group relative transition-all hover:brightness-90"
				style="width: {lang.percentage}%; background-color: {lang.color}"
			></div>
		{/each}
	</div>

	<!-- Language list -->
	<div class="col-span-4 mt-4 flex flex-wrap">
		{#each languages as lang}
			<div class="mr-2 flex items-center gap-2">
				<div class="h-3 w-3 rounded-full" style="background-color: {lang.color}"></div>
				<span class="text-sm text-gray-500">
					{lang.name}
					{lang.percentage}%
				</span>
			</div>
		{/each}
	</div>
</div>
